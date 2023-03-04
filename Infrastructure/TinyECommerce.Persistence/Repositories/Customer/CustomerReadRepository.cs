using TinyECommerce.Application.Repositories;
using TinyECommerce.Domain.Entities;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence.Repositories;

public class CustomerReadRepository: ReadRepository<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(TinyECommerceDbContext context) : base(context)
    {
    }
}