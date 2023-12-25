using BusinessLogic.DTO;

namespace BusinessLogic.Validation.Dish
{
    public static class DishValidation
    {
        public static void CheckDish(DishDTO dishDTO)
        {
            if (string.IsNullOrEmpty(dishDTO.Name))
            {
                throw new DishException($"{nameof(DishDTO.Name)} is empty.");
            }

            if (string.IsNullOrEmpty(dishDTO.Description))
            {
                throw new DishException($"{nameof(DishDTO.Description)} is empty.");
            }
        }

    }
}
