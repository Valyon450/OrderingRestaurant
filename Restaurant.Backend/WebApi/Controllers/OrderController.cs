using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
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
        public ActionResult<IEnumerable<OrderDTO>> Get()
        {
            var orders = _orderService.GetAll();

            return orders.ToList();
        }

        // GET api/<OrderController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderDTO orderModel)
        {
            try
            {
                await _orderService.AddAsync(orderModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return CreatedAtAction(nameof(Post), new { orderModel.Id }, orderModel);
        }

        // PUT api/<OrderController>/id
        [HttpPut]
        public async Task<ActionResult> Put(OrderDTO orderModel)
        {
            try
            {
                await _orderService.UpdateAsync(orderModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        // DELETE api/<OrderController>/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _orderService.DeleteByIdAsync(id);

            return Ok();
        }

        // GET: api/<DishController>
        [HttpGet("order-items")]
        public ActionResult<IEnumerable<OrderItemDTO>> GetOrderItems(Guid orderId)
        {
            var orderItems = _orderService.GetOrderItems(orderId);
            return orderItems.ToList();
        }

        // POST api/<DishController>
        [HttpPost("order-items")]
        public async Task<ActionResult> AddOrderItem([FromBody] OrderItemDTO orderItemModel)
        {
            try
            {
                await _orderService.AddOrderItemAsync(orderItemModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return CreatedAtAction(nameof(Post), new { orderItemModel.Id }, orderItemModel);
        }

        // DELETE api/<DishController>/id
        [HttpDelete("order-item/{orderItemId}")]
        public async Task<ActionResult> DeleteOrderItem(Guid orderItemId)
        {
            await _orderService.DeleteOrderItemByIdAsync(orderItemId);

            return Ok();
        }
    }
}
