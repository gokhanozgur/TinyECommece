using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        /*
         * The following definitions allow the request to the API to reach persistence through the application layer.
         * Example: When call IProductService type, return ProductService.
         */
        // @todo register service here
        
        /*
         * The following definitions allow the any database connection string declarations.
         */
        services.AddDbContext<TinyECommerceDbContext>(options => options.UseNpgsql(Configuration.PostgreSqlConnectionString));
    }
}