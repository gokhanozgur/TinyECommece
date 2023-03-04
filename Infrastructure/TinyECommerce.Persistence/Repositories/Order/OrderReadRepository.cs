using TinyECommerce.Application.Repositories;
using TinyECommerce.Domain.Entities;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence.Repositories;

public class OrderReadRepository: ReadRepository<Order>, IOrderReadRepository
{
    public OrderReadRepository(TinyECommerceDbContext context) : base(context)
    {
    }
}