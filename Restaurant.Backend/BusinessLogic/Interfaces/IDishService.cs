using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IDishService : ICrud<DishDTO>
    {
        IEnumerable<IngredientDTO> GetIngredients(Guid modelId);

        Task AddIngredientAsync(IngredientDTO model);

        Task DeleteIngredientByIdAsync(Guid modelId);
    }
}
