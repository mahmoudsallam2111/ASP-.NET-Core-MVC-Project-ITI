using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Online_Book_Store.Controllers
{
    public class DatasourceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult setTemp()
        {
            TempData["mes"] = "hello from temp data";
            return Content("temp added");
        }

        public IActionResult getTemp()
        {
            var res = TempData["mes"]; 
            return Content($"{res}");
        }

        public IActionResult setcookies()
        {
            CookieOptions co = new CookieOptions();
            co.Expires = DateTimeOffset.Now.AddDays(1);

            Response.Cookies.Append("name", "mahmoud" , co);
            Response.Cookies.Append("color", "red");
            Response.Cookies.Append("c", "22");
            return Content("cookies added");
        }

        public IActionResult getcookies()
        {
            string name = Request.Cookies["name"];
            string color = Request.Cookies["color"];
            string age = Request.Cookies["age"];
            return Content("red reom cookies");
            
        }



    }
}
