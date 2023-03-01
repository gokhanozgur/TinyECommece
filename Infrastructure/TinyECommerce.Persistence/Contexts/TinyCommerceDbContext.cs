using Microsoft.EntityFrameworkCore;
using TinyECommerce.Domain.Entities;

namespace TinyECommerce.Persistence.Contexts;

public class TinyCommerceDbContext: DbContext
{
    public TinyCommerceDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
}