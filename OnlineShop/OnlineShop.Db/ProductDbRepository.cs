using OnlineShop.Db.Models;

namespace OnlineShop.Db
{

    public class ProductDbRepository : IProductRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }
        public Product Get(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == id);
        }
        public void Add(Product product)
        {
            product.ImagePath = "images/image1.png";
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
            
        }
        public void Remove(Guid id)
        {
            databaseContext.Products.Remove(Get(id));
            databaseContext.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = databaseContext.Products.FirstOrDefault(x=>x.Id == product.Id);
            if(existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            databaseContext.SaveChanges();
        }
    }
}
