using TinyECommerce.Application.Repositories;
using TinyECommerce.Domain.Entities;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence.Repositories;

public class ProductWriteRepository: WriteRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(TinyECommerceDbContext context) : base(context)
    {
    }
}