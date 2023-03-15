using Microsoft.AspNetCore.Mvc;
using Online_Book_Store.Controllers.DB;
using Online_Book_Store.ViewModel;
using System.Data;

namespace Online_Book_Store.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ExaminationSysContext _db;

        public TraineeController(ExaminationSysContext _db)
        {
            this._db = _db;
            
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Showresult(int id , int crsid)
        {
           if (id ==null || crsid == null)
           {
                return NotFound();
           }
            var results = (from cr in _db.crsResults
                           join t in _db.trainees on cr.trainee_id equals t.Id
                           join c in _db.courses on cr.crs_id equals c.Id
                           select new
                           {
                               traineeid = t.Id,
                               TraineeName = t.Name,
                               CourseName = c.Name,
                               CourseDegree = c.Degree,
                               ResultDegree = cr.degree,
                               minimaldegree=c.Mindegree,
                               courseid = c.Id
                           }).Where(a => a.traineeid == id && a.courseid == crsid).FirstOrDefault();

            Traineewithcoursecs studenteva = new Traineewithcoursecs();

            studenteva.traniee_name = results.TraineeName;
            studenteva.course_name = results.CourseName;
            studenteva.mark = results.ResultDegree;
            if (results.ResultDegree > results.minimaldegree)
            {
                studenteva.color = "success";
            }
            else
            {
                studenteva.color = "danger";
            }

            return View("showresult" , studenteva);
        }






        // show result for a sepecific studdent
        public IActionResult getallresult(int id)
        {
           
           
            var results = (from cr in _db.crsResults
                           join t in _db.trainees on cr.trainee_id equals t.Id
                           join c in _db.courses on cr.crs_id equals c.Id
                           select new
                           {
                               traineeid = t.Id,
                               TraineeName = t.Name,
                               CourseName = c.Name,
                               CourseDegree = c.Degree,
                               ResultDegree = cr.degree,
                               minimaldegree = c.Mindegree,
                               courseid = c.Id
                           }).Where(a=>a.traineeid==id);

            foreach (var item in results)
            {
                TempData["stdname"] = item.TraineeName;

            }

            return View("getallresul", results);
        }




    }
}
