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
    public class IndexModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public IndexModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }

        public PromotionGift SelectedPromotionGift { get; set; }

        public async Task OnGetAsync(int? promotionGiftId)
        {
            Product = await _context.Products.ToListAsync();
            SelectedPromotionGift = await _context.PromotionGifts.FindAsync(promotionGiftId);

            if (SelectedPromotionGift == null) { RedirectToPage("../Index"); }
        }
    }
}
