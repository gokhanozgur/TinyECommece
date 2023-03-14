using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TinyECommerce.Application.Repositories;
using TinyECommerce.Persistence.Contexts;
using TinyECommerce.Persistence.Repositories;

namespace TinyECommerce.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        /*
         * The following definitions allow the any database connection string declarations.
         */
        services.AddDbContext<TinyECommerceDbContext>(options => options.UseNpgsql(Configuration.PostgreSqlConnectionString));

        /*
         * Definitions for repositories.
         */
        // Customer Repositories
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

        // Product Repositories
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        // Order Repositories
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
    }
}