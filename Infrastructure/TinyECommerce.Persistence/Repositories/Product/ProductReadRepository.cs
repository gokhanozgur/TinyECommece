using TinyECommerce.Application.Repositories;
using TinyECommerce.Domain.Entities;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence.Repositories;

public class ProductReadRepository: ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(TinyECommerceDbContext context) : base(context)
    {
    }
}