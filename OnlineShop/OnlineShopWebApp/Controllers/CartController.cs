using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller 
    {
        private readonly IProductRepository productStorage;
        private readonly ICartsRepository cartsStorage;
        public CartController(IProductRepository productStorage, ICartsRepository cartsStorage)
        {
            this.productStorage = productStorage;
            this.cartsStorage = cartsStorage;
        }

        public IActionResult Index()
        {
            var cart = cartsStorage.TryGetByUserId(Constants.UserId);
            return View(cart.ToCartViewModel());
        }
        public IActionResult Add(Guid productId)
        {
            var product = productStorage.Get(productId);
            cartsStorage.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        
        public IActionResult DecreaseAmount(Guid productId)
        {
            
            cartsStorage.DecreaseAmount(productId, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            cartsStorage.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
