using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.CustomerManager
{
    public class IndexModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public IndexModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }
       

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
