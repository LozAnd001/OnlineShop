using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsStorage;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsStorage, IOrdersRepository ordersRepository)
        {
            this.cartsStorage = cartsStorage;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Buy(UserDeliveryInfoViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", user);
            }
            var existingCart = cartsStorage.TryGetByUserId(Constants.UserId);
            //var existingCartViewModel = Mapping.ToCartViewModel(existingCart);
            var order = new Order
            {
                User = user.ToUser(),
                Items = existingCart.Items

            };
            cartsStorage.Clear(Constants.UserId);
            ordersRepository.Add(order);
            return View();
        }
    }
}
