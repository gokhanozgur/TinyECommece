using Microsoft.Extensions.DependencyInjection;
using TinyECommerce.Application.Abstractions;
using TinyECommerce.Persistence.Concretes;

namespace TinyECommerce.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        /*
         * The following definitions allow the request to the API to reach persistence through the application layer.
         * Example: When call IProductService type, return ProductService.
         */
        services.AddSingleton<IProductService, ProductService>();
    }
}