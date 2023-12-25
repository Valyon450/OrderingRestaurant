using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Validation.Dish;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace BusinessLogic.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork<Dish> _unit;
        private readonly IUnitOfWork<Ingredient> _unitIngredient;
        private readonly IMapper _mapper;

        public DishService(IUnitOfWork<Dish> unit, IUnitOfWork<Ingredient> unitIngredient, IMapper mapper)
        {
            _unit = unit;
            _unitIngredient = unitIngredient;
            _mapper = mapper;
        }

        public IEnumerable<DishDTO> GetAll()
        {
            var dishes = _unit.Repository.GetAll();

            return _mapper.Map<IEnumerable<DishDTO>>(dishes);
        }

        public async Task AddAsync(DishDTO model)
        {
            DishValidation.CheckDish(model);

            var dish = _mapper.Map<Dish>(model);

            await _unit.Repository.AddAsync(dish);
            await _unit.SaveAsync();

            model.Id = dish.Id;
        }

        public async Task<DishDTO> GetByIdAsync(Guid id)
        {
            var dish = await _unit.Repository.GetByIdAsync(id);

            return _mapper.Map<DishDTO>(dish);
        }

        public async Task UpdateAsync(DishDTO model)
        {
            DishValidation.CheckDish(model);
            var existingDish = await _unit.Repository.GetByIdAsync(model.Id);

            if (existingDish != null)
            {
                _mapper.Map(model, existingDish);

                await _unit.SaveAsync();
            }
        }

        public async Task DeleteByIdAsync(Guid modelId)
        {
            await _unit.Repository.DeleteByIdAsync(modelId);
            await _unit.SaveAsync();
        }

        public IEnumerable<IngredientDTO> GetIngredients(Guid dishId)
        {
            var ingredients = _unitIngredient.Repository.GetAll()
                .Where(ingredient => ingredient.Dishes.Any(dish => dish.Id == dishId));

            return _mapper.Map<IEnumerable<IngredientDTO>>(ingredients);
        }

        public async Task AddIngredientAsync(IngredientDTO model)
        {
            var ingredient = _mapper.Map<Ingredient>(model);

            await _unitIngredient.Repository.AddAsync(ingredient);
            await _unitIngredient.SaveAsync();

            model.Id = ingredient.Id;
        }

        public async Task DeleteIngredientByIdAsync(Guid modelId)
        {
            await _unitIngredient.Repository.DeleteByIdAsync(modelId);
            await _unitIngredient.SaveAsync();
        }
    }
}
