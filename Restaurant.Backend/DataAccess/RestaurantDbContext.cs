using DataAccess.Entities;
using DataAccess.EntityTypeConfigurations;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class RestaurantDbContext : DbContext, IRestaurantDbContext
    {        
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Dish> Dishes { get; set; } = default!;
        public DbSet<Ingredient> Ingredients { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
        public DbSet<PriceListNote> PriceListNotes { get; set; } = default!;

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress;Database=Restaurant;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new DishConfiguration());
            builder.ApplyConfiguration(new IngredientConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new PriceListNoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
