using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace WebApi.DI
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureDependency(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IRepository<OrderItem>, Repository<OrderItem>>();
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<IRepository<PriceListNote>, Repository<PriceListNote>>();
            services.AddScoped<IRepository<Dish>, Repository<Dish>>();
            services.AddScoped<IRepository<Ingredient>, Repository<Ingredient>>();

            services.AddScoped<IUnitOfWork<Order>, UnitOfWork<Order>>();
            services.AddScoped<IUnitOfWork<OrderItem>, UnitOfWork<OrderItem>>();
            services.AddScoped<IUnitOfWork<Customer>, UnitOfWork<Customer>>();
            services.AddScoped<IUnitOfWork<PriceListNote>, UnitOfWork<PriceListNote>>();
            services.AddScoped<IUnitOfWork<Dish>, UnitOfWork<Dish>>();
            services.AddScoped<IUnitOfWork<Ingredient>, UnitOfWork<Ingredient>>();

            // Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
