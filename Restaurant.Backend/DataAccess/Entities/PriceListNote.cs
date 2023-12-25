using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class PriceListNote : BaseEntity
    {
        // foreign key
        public Guid DishId { get; set; }
        public string PortionSize { get; set; }
        public decimal Price { get; set; }

        // many-to-one
        [ForeignKey(nameof(DishId))]
        public virtual Dish Dish { get; set; }
    }
}
