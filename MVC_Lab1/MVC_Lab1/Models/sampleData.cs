using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using MVC_Lab1.Controllers;

namespace MVC_Lab1.Models
{
    public class sampleData
	{
        static List<Product> products = new List<Product>()
        {



           new Product() { Id = 1,Description = "perfume 1",Image = "1.jfif",Name = "perfume 1",Price = 90},
            new Product() { Id = 2,Description = "perfume 2",Image = "2.jfif",Name = "perfume 2",Price = 200},
            new Product() { Id = 3,Description = "perfume 3",Image = "3.jfif",Name = "perfume 3", Price = 150},
            new Product() { Id = 4,Description = "perfume 4",Image = "4.jfif",Name = "perfume 4", Price = 500},

         };
        /// this are the bussiness functions
       
      public static List<Product> GetAll() { 

            return products;
        
      }

       public static Product GetById(int id)
        {
            return products.FirstOrDefault(a => a.Id == id);

        }
    }
}
