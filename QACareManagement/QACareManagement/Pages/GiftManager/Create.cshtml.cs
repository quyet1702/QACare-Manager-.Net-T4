using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.GiftManager
{
    public class CreateModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public CreateModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DealerCustomerId"] = new SelectList(_context.Customers, "Id", "FullName");
        ViewData["RegisterLocationCustomerAddressId"] = new SelectList(_context.CustomerAddresses, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public PromotionGift PromotionGift { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PromotionGifts.Add(PromotionGift);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
