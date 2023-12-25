using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class OrderItem : BaseEntity
    {
        // foreign key
        public Guid OrderId { get; set; }

        // foreign key
        public Guid PriceListNoteId { get; set; }

        public int Quantity { get; set; }

        // many-to-one
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        // one-to-one
        [ForeignKey(nameof(PriceListNoteId))]
        public virtual PriceListNote PriceListNote { get; set; }
    }
}
