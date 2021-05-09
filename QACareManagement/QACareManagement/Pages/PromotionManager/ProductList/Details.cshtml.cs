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
    public class DetailsModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public DetailsModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public PromotionGiftProduct PromotionGiftProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PromotionGiftProduct = await _context.PromotionGiftProducts
                .Include(p => p.Product)
                .Include(p => p.PromotionGift).FirstOrDefaultAsync(m => m.ProductId == id);

            if (PromotionGiftProduct == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
