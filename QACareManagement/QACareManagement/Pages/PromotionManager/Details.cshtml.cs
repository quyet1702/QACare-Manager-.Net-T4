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
    public class DetailsModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public DetailsModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

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
    }
}
