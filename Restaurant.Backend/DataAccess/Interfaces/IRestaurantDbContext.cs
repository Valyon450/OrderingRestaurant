using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interfaces
{
    public interface IRestaurantDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Dish> Dishes { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<PriceListNote> PriceListNotes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
