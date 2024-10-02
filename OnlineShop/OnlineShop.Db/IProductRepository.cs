using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Remove(Guid id);
    }
}