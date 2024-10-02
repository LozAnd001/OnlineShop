using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productStorage;
        private readonly ICartsRepository cartStorage;

        public HomeController(IProductRepository productStorage, ICartsRepository cartStorage)
        {
            this.productStorage = productStorage;
            this.cartStorage = cartStorage;
        }

        public IActionResult Index()
       {
            var products = productStorage.GetAll();
            return View(products.ToProductViewModels()); 
       }
        
    }
}
