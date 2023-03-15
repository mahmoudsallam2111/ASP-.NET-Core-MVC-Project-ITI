using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Controllers.DB;
using Online_Book_Store.Models;
using Online_Book_Store.ViewModel;

namespace Online_Book_Store.Controllers
{
    public class CourseController : Controller
    {
        private readonly ExaminationSysContext _db;
        public CourseController(ExaminationSysContext _db)
        {
            this._db=_db;
            
        }

        public IActionResult Index()
        {
            var courselist =( from c in _db.courses
                             join d in _db.Departments on c.dept_id equals d.Id

                             select new
                             {
                                 courseid = c.Id,
                                 coursename = c.Name,
                                 coursedegree = c.Degree,
                                 coursemindegree = c.Mindegree,
                                 deptname = d.Name,
                             }).ToList();
            return View(courselist);
        }


      //get
        public IActionResult AddCourse()
        {
            
            List<Department> deptlist = _db.Departments.ToList();

            
            ViewData["deptlist"] = deptlist;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse(Course obj)
        {
           
            List<Department> deptlist = _db.Departments.ToList();
            ViewData["deptlist"] = deptlist;

            if (obj.Name != null)
            {

                _db.courses.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "item added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }





        // get method
        public IActionResult edit(int id)
        {
            
            List<Department> deptlist = _db.Departments.ToList();

          
            ViewData["deptlist"] = deptlist;


            if (id == null || id == 0)
            {
                return NotFound();
            }

      


            var crs = _db.courses.SingleOrDefault(a => a.Id == id);

            if (crs == null)
            {
                return NotFound();
            }

            return View("Edit", crs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult edit(Course obj)
        {
            List<Department> deptlist = _db.Departments.ToList();

            ViewData["deptlist"] = deptlist;

            if (obj.Name !=null)
            {
                _db.courses.Update(obj);
                _db.SaveChanges();
                // temp data must be before return
                TempData["success"] = "item updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);

        }



        //get
        public IActionResult delete(int id)
        {
            List<Department> deptlist = _db.Departments.ToList();


            ViewData["deptlist"] = deptlist;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var crs = _db.courses.SingleOrDefault(a => a.Id == id);
            if (crs == null)
            {
                return NotFound();
            }


            return View("Delete", crs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult delete(Course obj)
        {
            List<Department> deptlist = _db.Departments.ToList();


            ViewData["deptlist"] = deptlist;


            _db.courses.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "item deleted successfully";
            return RedirectToAction("Index");

        }


    }
}
