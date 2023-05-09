using WebApi_Practice.Entities;
using WebApi_Practice.Repositories.Abstract;
using WebApi_Practice.Services.Abstract;

namespace WebApi_Practice.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product entity)
        {
            _productRepository.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public Product Get(int id)
        {
           return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
