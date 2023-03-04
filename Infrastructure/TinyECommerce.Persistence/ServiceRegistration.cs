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
        services.AddDbContext<TinyECommerceDbContext>(options => options.UseNpgsql(Configuration.PostgreSqlConnectionString), ServiceLifetime.Singleton);
        
        /*
         * Definitions for repositories.
         */
        // Customer Repositories
        services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
        services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();

        // Product Repositories
        services.AddSingleton<IProductReadRepository, ProductReadRepository>();
        services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();

        // Order Repositories
        services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
        services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
    }
}