using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize(Roles = Constants.AdminRoleName)]
    public class AdminController : Controller
    {
        private readonly IProductRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;
        public AdminController(IProductRepository productsRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
        }
        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAll();

            return View(orders.ToOrderViewModels());
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            var orderViewModel = order.ToOrderViewModel();
            return View(orderViewModel);
        }
        public IActionResult UpdateOrderStatus(Guid orderID, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderID, status);
            return RedirectToAction("Orders");
        }
        public IActionResult Users()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult Roles()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult RemoveRole(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction("Roles");
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if(rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if(ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }

            return View(role);
        }
        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products.ToProductViewModels());
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
            };
            productsRepository.Add(productDb);
            return RedirectToAction("Products");
        }
        public IActionResult EditProduct(Guid productId)
        {
            var product = productsRepository.Get(productId);
            var productView = product.ToProductViewModel();
            return View(productView);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductViewModel product)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(product);
            //}
            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Id = product.Id
                
            };
            productsRepository.Update(productDb);
            return RedirectToAction("Products");
        }
        public IActionResult RemoveProduct(Guid productId)
        {
            productsRepository.Remove(productId);
            return RedirectToAction("Products");
        }
    }
}
