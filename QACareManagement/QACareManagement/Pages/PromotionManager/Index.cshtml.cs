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
    public class IndexModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public IndexModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public IList<PromotionGift> PromotionGift { get;set; }

        public async Task OnGetAsync()
        {
            PromotionGift = await _context.PromotionGifts
                .Include(p => p.RegisterLocationCustomerAddress).ThenInclude( ad => ad.Customer)
                .Include(p => p.RegisterLocationCustomerAddress).ToListAsync();
        }
    }
}
