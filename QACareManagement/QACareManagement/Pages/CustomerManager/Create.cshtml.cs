using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.CustomerManager
{
    public class CreateModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public CreateModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);

            int resultCode = await _context.SaveChangesAsync();

           
            // Di chuyển về page Edit cho việc update lại nếu cần
            return RedirectToPage("./Edit", new { id = Customer.Id });
        }
    }
}
