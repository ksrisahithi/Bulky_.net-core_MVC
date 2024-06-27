using Bulky.Models;
using Bulky.DataAcess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create(Category obj)
		{
           if(ModelState.IsValid)
            {
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category Created Successfully";
				return RedirectToAction("Index");
			}
           return View();
		}

		public IActionResult Edit(int? id)
		{
			if(id == null || id == 0 )
			{
				return NotFound();
			}
			Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
			if(category == null)
			{
				return NotFound();
			}
			return View(category);
		}
		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category Updated Successfully";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category? obj = _db.Categories.Find(id);
			if(obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category Deleted Successfully";
			return RedirectToAction("Index");
		}
	}
}
