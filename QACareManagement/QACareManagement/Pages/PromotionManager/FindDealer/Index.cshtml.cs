using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.PromotionManager.FindDealer
{
    public class IndexModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public IndexModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public IList<CustomerAddress> CustomerAddress { get;set; }
        public PromotionGift SelectedPromotionGift { get; set; }

        public async Task OnGetAsync(int? promotionGiftId)
        {
            CustomerAddress = await _context.CustomerAddresses
                .Include(c => c.Customer)
                .OrderBy(c => c.CustomerId)
                .ToListAsync();
            SelectedPromotionGift = await _context.PromotionGifts.FindAsync(promotionGiftId);
        }

        [BindProperty]
        public int PromotionGiftId { get; set; }
        [BindProperty]
        public int CustomerAddressID { get; set; }

        public async Task<IActionResult> OnPostAsync( )
        {

            PromotionGift promotionGift = await _context.PromotionGifts.FindAsync(PromotionGiftId);

            promotionGift.RegisterLocationCustomerAddressId = CustomerAddressID;

            _context.Attach(promotionGift).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToPage("../Edit", new { Id = PromotionGiftId });

        }
    }
}
