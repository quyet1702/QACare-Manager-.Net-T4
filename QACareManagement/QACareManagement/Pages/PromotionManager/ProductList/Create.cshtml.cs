using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.PromotionManager.ProductList
{
    public class CreateModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public CreateModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }


        public PromotionGift SelectedPromotionGift { get; set; }

        public Product SelectedProduct { get; set; }

        public IActionResult OnGet(int? promotionGiftId, int? productId)
        {
            SelectedPromotionGift = _context.PromotionGifts.Find(promotionGiftId);
            SelectedProduct = _context.Products.Find(productId);

            if (SelectedProduct == null || SelectedPromotionGift == null) {
                return RedirectToPage("./Index");

            }

            return Page();
        }

        [BindProperty]
        public PromotionGiftProduct PromotionGiftProduct { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PromotionGiftProducts.Add(PromotionGiftProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Edit", new {   Id = PromotionGiftProduct.Id
            });
        }
    }
}
