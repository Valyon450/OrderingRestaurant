using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IOrderService : ICrud<OrderDTO>
    {
        IEnumerable<OrderItemDTO> GetOrderItems(Guid modelId);

        Task AddOrderItemAsync(OrderItemDTO model);

        Task DeleteOrderItemByIdAsync(Guid modelId);
    }
}
