using Microsoft.AspNetCore.Mvc;
using WebApi_Practice.Dtos;
using WebApi_Practice.Entities;
using WebApi_Practice.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Practice.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            return _productService.GetAll().Select(p =>
            {
                return new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Discount = p.Discount,
                    Price = p.Price
                };
            });
        }

        [HttpGet("HigherDiscounted")]
        public IEnumerable<ProductDto> GetHigherDiscounted()
        {
            var products = _productService.GetAll().Where(p => p.Discount >= 7);
            return products.Select(p =>
            {
                return new ProductDto
                {
                    Id = p.Id,
                    Discount = p.Discount,
                    Name = p.Name,
                    Price = p.Price 
                };
            });
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            var item = _productService.Get(id);
            return new ProductDto
            {
                Id = item.Id,
                Name = item.Name,
                Discount = item.Discount,
                Price = item.Price
            };
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto productDto)
        {
            try
            {
                var item = new Product
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Discount = productDto.Discount
                };
                _productService.Add(item);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto productDto)
        {
            try
            {
                var item = _productService.Get(id);

                item.Name = productDto.Name;
                item.Discount = productDto.Discount;
                item.Price = productDto.Price;

                _productService.Update(item);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _productService.Get(id);
                _productService.Delete(item);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
