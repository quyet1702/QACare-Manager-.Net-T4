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
    public class DetailsModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public DetailsModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public CustomerAddress CustomerAddress { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerAddress = await _context.CustomerAddresses
                .Include(c => c.Customer).FirstOrDefaultAsync(m => m.Id == id);

            if (CustomerAddress == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
