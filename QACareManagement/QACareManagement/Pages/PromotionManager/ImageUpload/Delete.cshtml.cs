using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.PromotionManager.ImageUpload
{
    public class DeleteModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public DeleteModel(QACareManagement.DataModel.QACareContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PromotionGiftImageUpload = await _context.PromotionGiftImageUploads.FindAsync(id);

            if (PromotionGiftImageUpload != null)
            {
                _context.PromotionGiftImageUploads.Remove(PromotionGiftImageUpload);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
