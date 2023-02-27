using TinyECommerce.Domain.Entities;

namespace TinyECommerce.Application.Abstractions;

public interface IProductService
{
    List<Product> GetProducts();
}