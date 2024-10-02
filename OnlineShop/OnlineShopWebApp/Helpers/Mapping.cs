using Microsoft.Identity.Client;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(product.ToProductViewModel());
            }
            return productsViewModels;
        }
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath,
            };
        }
        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if(cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items.ToCartItemViewModels()
            };
        }
        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(this UserDeliveryInfo User)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = User.Name,
                Address = User.Address,
                Phone = User.Phone,
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order) 
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CreateDateTime = order.CreateDateTime,
                Status = (OrderStatusViewModel)(int)order.Status,
                User = order.User.ToUserDeliveryInfoViewModel(),
                Items = order.Items.ToCartItemViewModels()
            };
        }
        public static List<OrderViewModel> ToOrderViewModels(this List<Order> orders)
        {
            var orderViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                orderViewModels.Add(order.ToOrderViewModel());
            }
            return orderViewModels;
        }
        public static UserDeliveryInfo ToUser(this UserDeliveryInfoViewModel User)
        {
            return new UserDeliveryInfo
            {
                Name = User.Name,
                Address = User.Address,
                Phone = User.Phone,
            };
        }
        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var carItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id, 
                    Amount = cartDbItem.Amount,
                    Product = cartDbItem.Product.ToProductViewModel()

                };
                cartItems.Add(carItem);

            }
            return cartItems;
        }
    }
}
