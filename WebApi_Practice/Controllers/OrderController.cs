using Microsoft.AspNetCore.Mvc;
using WebApi_Practice.Dtos;
using WebApi_Practice.Entities;
using WebApi_Practice.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderDto> Get()
        {
            return _orderService.GetAll().Select(o =>
            {
                return new OrderDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    OrderDate = o.OrderDate,
                    ProductId = o.ProductId
                };
            });
        }

       
        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderDto Get(int id)
        {
            var item = _orderService.Get(id);

            return new OrderDto
            {
                Id = item.Id,
                OrderDate = item.OrderDate,
                CustomerId = item.CustomerId,
                ProductId = item.ProductId
            };
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto value)
        {
            try
            {
                var dataToAdd = new Order
                {
                    Id = value.Id,
                    CustomerId = value.CustomerId,
                    OrderDate = value.OrderDate,
                    ProductId = value.ProductId

                };
                _orderService.Add(dataToAdd);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDto value)
        {
            try
            {
                var item = _orderService.Get(id);
                item.OrderDate = value.OrderDate;
                item.ProductId = value.ProductId;
                item.CustomerId = value.CustomerId;
                _orderService.Update(item);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var dataToDelete = _orderService.Get(id);
                _orderService.Delete(dataToDelete);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
