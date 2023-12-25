using BusinessLogic.DTO;

namespace BusinessLogic.Validation.Order
{
    public static class OrderValidation
    {
        public static void CheckOrder(OrderDTO orderDTO)
        {
            if (orderDTO.CustomerId == Guid.Empty)
            {
                throw new OrderException($"{nameof(OrderDTO.CustomerId)} should be valid.");
            }

            if (string.IsNullOrEmpty(orderDTO.Details))
            {
                throw new OrderException($"{nameof(OrderDTO.Details)} is empty.");
            }

            if (orderDTO.TotalOrderAmount <= 0)
            {
                throw new OrderException($"{nameof(OrderDTO.TotalOrderAmount)} should be greater than zero.");
            }
        }
    }
}


