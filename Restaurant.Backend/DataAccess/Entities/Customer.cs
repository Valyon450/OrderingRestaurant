namespace DataAccess.Entities
{
    public class Customer : BaseEntity
    {
        public string SurName { get; set; }
        public string Name { get; set; }

        // one-to-many
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
