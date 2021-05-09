using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.CustomerManager.Address
{
    public class CreateModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public CreateModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public Customer SelectedCustomer { get; set; }

        public IActionResult OnGet( int ? customerId)
        {
            SelectedCustomer = _context.Customers.Find(customerId);

            if (SelectedCustomer == null )
            {
                return RedirectToPage("../Index");
            }
           

            return Page();
        }

        [BindProperty]
        public CustomerAddress CustomerAddress { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomerAddresses.Add(CustomerAddress);
            await _context.SaveChangesAsync();

            // Di chuyển về page Edit cho việc update lại nếu cần
            return RedirectToPage("./Edit", new { id = CustomerAddress.Id });
        }
    }
}
