using BulkyWeb.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category CategoryEdit { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CategoryEdit = _db.Categories.Find(id);

            if (CategoryEdit == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _db.Categories.Update(CategoryEdit);
            _db.SaveChanges();
            TempData["success"] = "Category Updated Successfully";
            return RedirectToPage("Index");
        }
    }
}
