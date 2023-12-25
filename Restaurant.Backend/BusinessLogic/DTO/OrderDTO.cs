namespace BusinessLogic.DTO
{
    public class OrderDTO : BaseDTO
    {
        public Guid CustomerId { get; set; }
        public string Details { get; set; }
        public decimal TotalOrderAmount { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime EditDateTime { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
