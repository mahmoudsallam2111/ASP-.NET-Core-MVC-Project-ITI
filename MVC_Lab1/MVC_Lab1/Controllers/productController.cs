using Microsoft.AspNetCore.Mvc;
using MVC_Lab1.Models;
using System.Security.Cryptography.X509Certificates;

namespace MVC_Lab1.Controllers
{
	public class productController : Controller
	{
		public  IActionResult Index()
		{
		  	List<Product> productslist = sampleData.GetAll();
			return View("index", productslist);
		}

		public IActionResult Details(int id)
		{
			Product myproduct = sampleData.GetById(id);
			return View("details", myproduct);
		}
	}
}
