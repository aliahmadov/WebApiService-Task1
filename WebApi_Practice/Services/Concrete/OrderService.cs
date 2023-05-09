using WebApi_Practice.Entities;
using WebApi_Practice.Repositories.Abstract;
using WebApi_Practice.Services.Abstract;

namespace WebApi_Practice.Services.Concrete
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(Order entity)
        {
            _orderRepository.Add(entity);
        }

        public void Delete(Order entity)
        {
            _orderRepository.Delete(entity);
        }

        public Order Get(int id)
        {
            return _orderRepository.Get(id);
        }


        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void Update(Order entity)
        {
            _orderRepository.Update(entity);
        }
    }
}
