using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent: ViewComponent
    {
        private readonly ICartsRepository cartStorage;

        public CartViewComponent(ICartsRepository cartStorage)
        {
            this.cartStorage = cartStorage;
        }
        public IViewComponentResult Invoke()
        {
            var cart = cartStorage.TryGetByUserId(Constants.UserId);
            var cartViewModel = cart.ToCartViewModel();
            var productCounts = cartViewModel?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
