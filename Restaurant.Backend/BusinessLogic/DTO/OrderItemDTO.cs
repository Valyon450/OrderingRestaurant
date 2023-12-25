namespace BusinessLogic.DTO
{
    public class OrderItemDTO : BaseDTO
    {
        public Guid OrderId { get; set; }
        public Guid PriceListNoteId { get; set; }
        public int Quantity { get; set; }
    }
}
