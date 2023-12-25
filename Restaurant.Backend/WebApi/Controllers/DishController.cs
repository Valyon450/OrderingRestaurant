using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        // GET: api/<DishController>
        [HttpGet]
        public ActionResult<IEnumerable<DishDTO>> Get()
        {
            var dishes = _dishService.GetAll();
            return dishes.ToList();
        }

        // GET api/<DishController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DishDTO>>> GetById(Guid id)
        {
            var dish = await _dishService.GetByIdAsync(id);

            if (dish == null)
            {
                return NotFound();
            }

            return Ok(dish);
        }

        // POST api/<DishController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DishDTO dishModel)
        {
            try
            {
                await _dishService.AddAsync(dishModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return CreatedAtAction(nameof(Post), new { dishModel.Id }, dishModel);
        }

        // PUT api/<DishController>/id
        [HttpPut]
        public async Task<ActionResult> Put(DishDTO dishModel)
        {
            try
            {
                await _dishService.UpdateAsync(dishModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        // DELETE api/<DishController>/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _dishService.DeleteByIdAsync(id);

            return Ok();
        }

        // GET: api/<DishController>
        [HttpGet("ingredients")]
        public ActionResult<IEnumerable<IngredientDTO>> GetIngredients(Guid dishId)
        {
            var ingredients = _dishService.GetIngredients(dishId);
            return ingredients.ToList();
        }

        // POST api/<DishController>
        [HttpPost("ingredients")]
        public async Task<ActionResult> AddIngredient([FromBody] IngredientDTO ingredientModel)
        {
            try
            {
                await _dishService.AddIngredientAsync(ingredientModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return CreatedAtAction(nameof(Post), new { ingredientModel.Id }, ingredientModel);
        }

        // DELETE api/<DishController>/id
        [HttpDelete("ingredient/{ingredientId}")]
        public async Task<ActionResult> DeleteIngredient(Guid ingredientId)
        {
            await _dishService.DeleteIngredientByIdAsync(ingredientId);

            return Ok();
        }
    }
}
