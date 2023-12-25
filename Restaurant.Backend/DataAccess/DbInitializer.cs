namespace DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(RestaurantDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
