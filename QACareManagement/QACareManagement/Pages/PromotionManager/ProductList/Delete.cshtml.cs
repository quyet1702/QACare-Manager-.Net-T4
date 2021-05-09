using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.PromotionManager.ProductList
{
    public class DeleteModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public DeleteModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PromotionGiftProduct PromotionGiftProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PromotionGiftProduct = await _context.PromotionGiftProducts
                .Include(p => p.Product)
                .Include(p => p.PromotionGift)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (PromotionGiftProduct == null)
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

            PromotionGiftProduct = await _context.PromotionGiftProducts.FindAsync(id);

            if (PromotionGiftProduct != null)
            {
                _context.PromotionGiftProducts.Remove(PromotionGiftProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Edit", new { id = PromotionGiftProduct.PromotionGiftId });
        }
    }
}
