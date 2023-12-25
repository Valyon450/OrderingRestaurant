using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;

namespace BusinessLogic.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ReverseMap();

            CreateMap<Dish, DishDTO>()
                .ReverseMap();

            CreateMap<Ingredient, IngredientDTO>()
                .ReverseMap();

            CreateMap<Order, OrderDTO>()
                .ReverseMap();

            CreateMap<OrderItem, OrderItemDTO>()
                .ReverseMap();

            CreateMap<PriceListNote, PriceListNoteDTO>()
                .ReverseMap();
        }
    }
}
