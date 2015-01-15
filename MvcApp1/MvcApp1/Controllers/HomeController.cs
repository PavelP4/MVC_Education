using MvcApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using MvcApp1.ViewModels;

namespace MvcApp1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private Product[] products = {
            new Product {ProductID = 1, Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {ProductID = 2, Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {ProductID = 3, Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {ProductID = 4, Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        private IValueCalculator calc;

        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public ActionResult List()
        {
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            ListViewModel listVM = new ListViewModel() { Products = products, TotalPrice = cart.CalculateProductTotal()};

            return View(listVM);
        }

        public ViewResult Edit(int ProductID)
        {
            Product editProduct = products.FirstOrDefault<Product>(x => x.ProductID == ProductID);

            return View(editProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                TempData["Message"] = string.Format("Product [ID = {0}] was modified.", product.ProductID);
                return RedirectToAction("List");
            }            
        }

    }
}
