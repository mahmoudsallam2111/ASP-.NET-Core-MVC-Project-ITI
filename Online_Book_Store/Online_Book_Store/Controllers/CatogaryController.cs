using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Online_Book_Store.Controllers.DB;
using Online_Book_Store.Models;

namespace Online_Book_Store.Controllers
{
    public class CatogaryController : Controller
    {
        private readonly BookStoreContext _db;    
        public CatogaryController(BookStoreContext _db)
        {
            this._db = _db;
            
        }
        public IActionResult Index()
        {
            var catlist = _db.clategories.ToList();   

            return View("Index" , catlist);
        }

        // get method
        public IActionResult CreateCategory()
        {

            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Clategory obj)
        {
            // costum error
            if (obj.Name==obj.DisplayedOrder.ToString())
            {
                ModelState.AddModelError("name", "the DisplayedOrder can to be like Name");

            }
            if (ModelState.IsValid)
            {

                _db.clategories.Add(obj);
                _db.SaveChanges();
               TempData["success"] = "item added successfully";
                return RedirectToAction("Index");
               

            }
            return View(obj);
            
        }





        // get method
        public IActionResult EditCategory(int id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var cat = _db.clategories.SingleOrDefault(a=>a.Id==id);
            if (cat==null)
            {
                return NotFound();
            }
            return View("Edit",cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Clategory obj)
        {
            // costum error
            if (obj.Name == obj.DisplayedOrder.ToString())
            {
                ModelState.AddModelError("name", "the DisplayedOrder can to be like Name");

            }
            if (ModelState.IsValid)
            {

                _db.clategories.Update(obj);
                _db.SaveChanges();
                // temp data must be before return
                TempData["success"] = "item updated successfully";
                return RedirectToAction("Index");

            }
            return View(obj);

        }





        //get method
        public IActionResult DeleteCategory(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.clategories.SingleOrDefault(a => a.Id == id);
            if (cat == null)
            {
                return NotFound();
            }


            return View("Delete", cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(Clategory obj)
        { 
                _db.clategories.Remove(obj);
                _db.SaveChanges();
               TempData["success"] = "item deleted successfully";
            return RedirectToAction("Index");
            
        }




    }
}
