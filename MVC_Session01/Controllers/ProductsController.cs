using Microsoft.AspNetCore.Mvc;
using MVC_Session01.Models;

namespace MVC_Session01.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>()
            {
                new Product ()
                { 
                    Id = 1 ,
                    Name = "Iphone",
                    Price=50000
                },
                new Product()
                {
                    Id = 2,
                    Name="Laptop",
                    Price=20000
                }

            };
            return View(products);
        }

        public IActionResult Show(int id)
        {
            var product = new Product()
            {
                Id = id,
                Name = "Unknown",
                Price = 5000
            };
            return View(product);
        }

        public IActionResult Details(int id)
        {
            var product = new Product()
            {
                Id = id,
                Name = "Unknown",
                Price = 5000
            };
            return View(product);

        }

        public IActionResult GetProducts()
        {
            var products = new List<Product>()
            {
                new Product(){Id =1, Name= "Mobile"},
                new Product(){Id= 2, Name= "Tablet"}
            };
            return Json(products);
        }

        public IActionResult GetProductById(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Show));
            else if (id < 10)
                return NotFound();
            else
                return Json(new Product() { Id = id, Name = "Laptop" });
             
        }

        public IActionResult FileAction() 
        {
            byte[] bytes = System.IO.File.ReadAllBytes("wwwroot/files/Mohamed_Sayed_CV.pdf");
            return File(bytes, "application/pdf", "myCV.pdf");
        }
    }
}
