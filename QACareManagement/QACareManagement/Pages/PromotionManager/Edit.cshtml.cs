using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.PromotionManager
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

        public IList<PromotionGiftProduct> PromotionGiftProduct { get; set; }
        public IList<PromotionGiftImageUpload> PromotionGiftImageUpload { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PromotionGift = await _context.PromotionGifts

                .Include(p => p.RegisterLocationCustomerAddress)
                .ThenInclude(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (PromotionGift == null)
            {
                return NotFound();
            }

            PromotionGiftProduct = await _context.PromotionGiftProducts
                .Include(p => p.Product)
                .Where(p => p.PromotionGiftId == PromotionGift.Id)
                .ToListAsync();

            PromotionGiftImageUpload = await _context.PromotionGiftImageUploads
                 .Where(p => p.PromotionGiftId == PromotionGift.Id)
                .ToListAsync();

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

            PromotionGift.UpdateAt = DateTime.Now;

            _context.Attach(PromotionGift).State = EntityState.Modified;

            _context.Entry(PromotionGift).Property(x => x.CreateDate).IsModified = false;
            _context.Entry(PromotionGift).Property(x => x.CreateTime).IsModified = false;
            _context.Entry(PromotionGift).Property(x => x.StartDateRunning).IsModified = false;
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
