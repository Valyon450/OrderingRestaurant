using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
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
        public ActionResult<IEnumerable<CustomerDTO>> Get()
        {
            var customers = _customerService.GetAll();
            return customers.ToList();
        }

        // GET api/<CustomerController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetById(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerDTO customerModel)
        {
            try
            {
                await _customerService.AddAsync(customerModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return CreatedAtAction(nameof(Post), new { customerModel.Id }, customerModel);
        }

        // PUT api/<CustomerController>/id
        [HttpPut]
        public async Task<ActionResult> Put(CustomerDTO customerModel)
        {
            try
            {
                await _customerService.UpdateAsync(customerModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        // DELETE api/<CustomerController>/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _customerService.DeleteByIdAsync(id);

            return Ok();
        }
    }
}
