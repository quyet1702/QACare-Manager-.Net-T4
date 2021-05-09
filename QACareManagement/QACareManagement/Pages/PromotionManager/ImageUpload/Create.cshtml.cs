using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QACareManagement.DataModel;

namespace QACareManagement.Pages.PromotionManager.ImageUpload
{
    public class CreateModel : PageModel
    {
        private readonly QACareManagement.DataModel.QACareContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CreateModel(QACareManagement.DataModel.QACareContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }


        public PromotionGift SelectedPromotionGift { get; set; }

        public IActionResult OnGet(int? promotionGiftId)
        {
            SelectedPromotionGift =  _context.PromotionGifts.Find(promotionGiftId);

            return Page();
        }

        [BindProperty]
        public PromotionGiftImageUpload PromotionGiftImageUpload { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            

            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(PromotionGiftImageUpload.ImageFile.FileName);
            string extension = Path.GetExtension(PromotionGiftImageUpload.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("_yyMMdd-hhmmss") + extension;
            string path = Path.Combine(wwwRootPath + "/ImageFileUpload/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await PromotionGiftImageUpload.ImageFile.CopyToAsync(fileStream);
            }

            PromotionGiftImageUpload.FileName = fileName;
            PromotionGiftImageUpload.FileLocation = Path.Combine("/ImageFileUpload/", fileName); ;
          

            _context.PromotionGiftImageUploads.Add(PromotionGiftImageUpload);


            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
