using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.PromotionManager.ImageUpload
{
    public class EditModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public EditModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PromotionGiftImageUpload PromotionGiftImageUpload { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PromotionGiftImageUpload = await _context.PromotionGiftImageUploads
                .Include(p => p.PromotionGift).FirstOrDefaultAsync(m => m.Id == id);

            if (PromotionGiftImageUpload == null)
            {
                return NotFound();
            }
           ViewData["PromotionGiftId"] = new SelectList(_context.PromotionGifts, "Id", "Title");
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

            _context.Attach(PromotionGiftImageUpload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionGiftImageUploadExists(PromotionGiftImageUpload.Id))
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

        private bool PromotionGiftImageUploadExists(int id)
        {
            return _context.PromotionGiftImageUploads.Any(e => e.Id == id);
        }
    }
}
