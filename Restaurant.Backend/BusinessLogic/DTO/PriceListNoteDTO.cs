namespace BusinessLogic.DTO
{
    public class PriceListNoteDTO : BaseDTO
    {
        public Guid DishId { get; set; }
        public string PortionSize { get; set; }
        public decimal Price { get; set; }
    }
}
