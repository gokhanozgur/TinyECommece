using TinyECommerce.Application.Repositories;
using TinyECommerce.Domain.Entities;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence.Repositories;

public class OrderWriteRepository: WriteRepository<Order>, IOrderWriteRepository
{
    public OrderWriteRepository(TinyECommerceDbContext context) : base(context)
    {
    }
}