using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.CustomerManager.Address
{
    public class EditModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;

        public EditModel(QACareManagement.DataModel.QACareContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomerAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAddressExists(CustomerAddress.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Edit", new { id = CustomerAddress.Id });
        }

        private bool CustomerAddressExists(int id)
        {
            return _context.CustomerAddresses.Any(e => e.Id == id);
        }
    }
}
