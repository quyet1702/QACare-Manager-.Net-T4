using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.OrderManager
{
    public class EditModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public EditModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PromotionGift PromotionGift { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PromotionGift = await _context.PromotionGifts
                .Include(p => p.DealerCustomer)
                .Include(p => p.RegisterLocationCustomerAddress).FirstOrDefaultAsync(m => m.Id == id);

            if (PromotionGift == null)
            {
                return NotFound();
            }
           ViewData["DealerCustomerId"] = new SelectList(_context.Customers, "Id", "FullName");
           ViewData["RegisterLocationCustomerAddressId"] = new SelectList(_context.CustomerAddresses, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PromotionGift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionGiftExists(PromotionGift.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PromotionGiftExists(int id)
        {
            return _context.PromotionGifts.Any(e => e.Id == id);
        }
    }
}
