using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Details { get; set; }
        public decimal TotalOrderAmount { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime? EditDateTime { get; set; }

        // one-to-many
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // many-to-one
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
