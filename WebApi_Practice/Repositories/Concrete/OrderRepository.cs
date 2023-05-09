using WebApi_Practice.Data;
using WebApi_Practice.Entities;
using WebApi_Practice.Repositories.Abstract;

namespace WebApi_Practice.Repositories.Concrete
{
    public class OrderRepository : IOrderRepository
    {
         private readonly ECommerceDbContext _context;

        public OrderRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
    }
}
