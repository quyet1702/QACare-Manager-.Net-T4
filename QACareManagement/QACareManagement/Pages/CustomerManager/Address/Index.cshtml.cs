using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.CustomerManager.Address
{
    public class IndexModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public IndexModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public IList<CustomerAddress> CustomerAddress { get;set; }

        public async Task OnGetAsync()
        {
            CustomerAddress = await _context.CustomerAddresses
                .Include(c => c.Customer).ToListAsync();
        }
    }
}
