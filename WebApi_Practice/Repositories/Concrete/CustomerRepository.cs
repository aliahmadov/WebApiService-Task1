using WebApi_Practice.Data;
using WebApi_Practice.Entities;
using WebApi_Practice.Repositories.Abstract;

namespace WebApi_Practice.Repositories.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ECommerceDbContext _context;

        public CustomerRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }

        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }
    }
}
