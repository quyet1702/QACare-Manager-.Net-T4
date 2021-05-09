using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.PromotionManager
{
    public class DeleteModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public DeleteModel(QACareManagement.DataModel.QACareContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PromotionGift = await _context.PromotionGifts.FindAsync(id);

            if (PromotionGift != null)
            {
                _context.PromotionGifts.Remove(PromotionGift);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
