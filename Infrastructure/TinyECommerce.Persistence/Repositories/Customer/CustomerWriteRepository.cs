using TinyECommerce.Application.Repositories;
using TinyECommerce.Domain.Entities;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence.Repositories;

public class CustomerWriteRepository: WriteRepository<Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(TinyECommerceDbContext context) : base(context)
    {
    }
}