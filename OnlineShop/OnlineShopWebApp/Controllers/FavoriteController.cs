using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IProductRepository productsRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository, IProductRepository productsRepository)
        {
            this.favoriteRepository = favoriteRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = favoriteRepository.GetAll(Constants.UserId);
            return View(products.ToProductViewModels());
        }

        public IActionResult Add(Guid productId) 
        { 
            var product = productsRepository.Get(productId);
            favoriteRepository.Add(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            favoriteRepository.Remove(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
