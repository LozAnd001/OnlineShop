using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product("Name1", 10, "Desc1", "/images/image1.png"),
                new Product("Name2", 20, "Desc2", "/images/image2.png"),
                new Product("Name3", 30, "Desc3", "/images/image3.png"),
                new Product("Name4", 40, "Desc4", "/images/image4.jpg"),
                new Product("Name5", 50, "Desc5", "/images/image5.png"),

            });
        }
    }
}
