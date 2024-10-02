using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IFavoriteRepository
    {
        List<Product> GetAll(string userId);
        void Add(string userId, Product product);
        void Clear(string userId);
        void Remove(string userId, Guid productId);
    }
}