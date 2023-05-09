using WebApi_Practice.Entities;
using WebApi_Practice.Repositories.Abstract;
using WebApi_Practice.Services.Abstract;

namespace WebApi_Practice.Services.Concrete
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(Customer entity)
        {
            _customerRepository.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _customerRepository.Delete(entity);
        }

        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public void Update(Customer entity)
        {
            _customerRepository.Update(entity);
        }
    }
}
