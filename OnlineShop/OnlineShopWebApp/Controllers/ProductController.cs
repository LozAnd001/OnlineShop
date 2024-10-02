using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productStorage;
        public ProductController(IProductRepository productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index(Guid id)
        {
            var answer = productStorage.Get(id);
            return View(answer);
        }
    }
}
