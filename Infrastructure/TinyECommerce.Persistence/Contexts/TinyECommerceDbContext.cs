using Microsoft.EntityFrameworkCore;
using TinyECommerce.Domain.Entities;

namespace TinyECommerce.Persistence.Contexts;

public class TinyECommerceDbContext: DbContext
{
    public TinyECommerceDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
}