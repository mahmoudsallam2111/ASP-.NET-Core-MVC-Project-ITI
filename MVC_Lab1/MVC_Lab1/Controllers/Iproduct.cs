using MVC_Lab1.Models;

namespace MVC_Lab1.Controllers
{
    public  interface Iproduct
    {
      List<Product>GetAll();
        Product GetById(int id);
    }
}
