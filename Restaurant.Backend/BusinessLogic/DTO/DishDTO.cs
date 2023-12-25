namespace BusinessLogic.DTO
{
    public class DishDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IngredientDTO> Ingredients { get; set; }
    }
}
