using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using Online_Book_Store.Controllers.DB;
using Online_Book_Store.Models;
using Online_Book_Store.ViewModel;

namespace Online_Book_Store.Controllers
{
    //[Route("[controller]")]  //attribute route with token
    public class InstructorController : Controller
    {
       
        private readonly ExaminationSysContext _db;

        public InstructorController(ExaminationSysContext _db)
        {
            this._db = _db;
            
        }


        //[Route("[action]")] //attribute route with token
        public IActionResult Index()
        {
            var instructorslist = from i in _db.instructors
                                                join d in _db.Departments on i.dept_id equals d.Id
                                                join c in _db.courses on i.crs_id equals c.Id
                                                select new
                                                {
                                                   inst_id = i.Id,
                                                    name = i.Name,
                                                    image = i.Image,
                                                    salary = i.Salary,
                                                    address = i.Address,
                                                    cousename = c.Name,
                                                    departmentname = d.Name
                                                };

            return View("index" , instructorslist);
        }

        //[Route("[action]")] //attribute route with token
        public IActionResult details(int? id)
        {

            if (id==null || id==0)
            {
                return NotFound();
            }

            var instructor = _db.instructors.SingleOrDefault(i => i.Id == id);

           string res = _db.instructors.Where(i => i.Id==id).Select(a=>a.Name).SingleOrDefault().ToString();
            if (instructor==null)
            {
                return NotFound();
            }
            TempData["success"] = $"{res} Details";
            return View("~/Views/Instructor/details.cshtml", instructor);
        }


        public IActionResult AddInstructor()
        {
            List<Course> crslist = _db.courses.ToList();
            List<Department> deptlist = _db.Departments.ToList();

            ViewData["crslist"] = crslist;
            ViewData["deptlist"] = deptlist;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInstructor(Instructor obj)
        {
            List<Course> crslist = _db.courses.ToList();
            List<Department> deptlist = _db.Departments.ToList();

            ViewData["crslist"] = crslist;
            ViewData["deptlist"] = deptlist;

            if (ModelState.IsValid)
            {
            _db.instructors.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "item added successfully";
            return RedirectToAction("Index");
            }
            return View(obj);

        }

       






        // get method
        public IActionResult edit(int id)
        {
            List<Course> crslist = _db.courses.ToList();
            List<Department> deptlist = _db.Departments.ToList();

            var img = _db.instructors.Where(a => a.Id == id).Select(a=>a.Image).SingleOrDefault().ToString();

            ViewData["img"] = img;

            ViewData["crslist"] = crslist;
            ViewData["deptlist"] = deptlist;


            if (id == null || id == 0)
            {
                return NotFound();
            }

            mymodel instmodel = new mymodel();


            var ins = _db.instructors.SingleOrDefault(a => a.Id == id);

            if (ins == null)
            {
                return NotFound();
            }

            return View("Edit", ins);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult edit( int id,Instructor obj)
        {
            List<Course> crslist = _db.courses.ToList();
            List<Department> deptlist = _db.Departments.ToList();
           
            ViewData["crslist"] = crslist;
            ViewData["deptlist"] = deptlist;

           
            if (obj.Image == null && obj.Name != null && obj.Salary != null)
            {
                var old = _db.instructors.SingleOrDefault(a => a.Id == id);
                old.Id = obj.Id;
                old.Name = obj.Name;
                old.Image = obj.Image;
                old.Salary = obj.Salary;
                old.Address = obj.Address;
                old.crs_id = obj.crs_id;
                old.dept_id = obj.dept_id;

                return RedirectToAction("Index");

            }

            else if (obj.Name != null && obj.Image != null && obj.Salary != null)
            {
                _db.instructors.Update(obj);
                _db.SaveChanges();
                // temp data must be before return
                TempData["success"] = "item updated successfully";
                return RedirectToAction("Index");

            }

            return View(obj);
       

        }












    }
}
