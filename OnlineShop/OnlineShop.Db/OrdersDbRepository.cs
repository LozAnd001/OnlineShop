using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Models;


namespace OnlineShop.Db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return databaseContext.Orders.Include(x => x.User)
                .Include(x => x.Items).ThenInclude(x => x.Product).ToList();
        }

        public Order TryGetById(Guid id)
        {
            return databaseContext.Orders.Include(x => x.User)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == id);
        }
        public void Remove(Order order)
        {
            databaseContext.Orders.Remove(order);
            databaseContext.SaveChanges();
        }

        public void UpdateStatus(Guid orderID, OrderStatus newStatus)
        {
            var order = TryGetById(orderID);
            if(order != null)
            {
                Remove(order);
                order.Status = newStatus;
                Add(order);
            }

        }
    }
}
