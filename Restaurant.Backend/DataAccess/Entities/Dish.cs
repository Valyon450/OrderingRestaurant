namespace DataAccess.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // many-to-many
        public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        // one-to-many
        public virtual ICollection<PriceListNote> PriceListNotes { get; set; } = new List<PriceListNote>();
    }
}