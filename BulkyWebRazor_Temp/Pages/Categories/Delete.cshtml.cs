using BulkyWeb.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category CategoryDelete { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CategoryDelete = _db.Categories.Find(id);

            if (CategoryDelete == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CategoryDelete = _db.Categories.Find(id);

            if (CategoryDelete == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(CategoryDelete);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted  Successfully";
            return RedirectToPage("Index");
        }
    }
}
