namespace DataAccess.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // many-to-many
        public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
