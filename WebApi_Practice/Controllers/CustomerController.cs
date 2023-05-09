using Microsoft.AspNetCore.Mvc;
using WebApi_Practice.Dtos;
using WebApi_Practice.Entities;
using WebApi_Practice.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            return _customerService.GetAll().Select(p =>
            {
                return new CustomerDto
                {
                    Id=p.Id,
                    Name = p.Name,
                    Surname = p.Surname
                };
            });
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerDto Get(int id)
        {
            var item = _customerService.Get(id);

            return new CustomerDto
            {
                Id = id,
                Name=item.Name,
                Surname=item.Surname
            };
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customer)
        {
            try
            {
                var dataToAdd = new Customer
                {
                    Name = customer.Name,
                    Surname = customer.Surname,

                };
                _customerService.Add(dataToAdd);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDto value)
        {
            try
            {
                var item = _customerService.Get(id);
                item.Name = value.Name;
                item.Surname = value.Surname;
                _customerService.Update(item);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var item= _customerService.Get(id);
                _customerService.Delete(item);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
