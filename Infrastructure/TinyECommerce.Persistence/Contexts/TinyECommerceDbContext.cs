using Microsoft.EntityFrameworkCore;
using TinyECommerce.Domain.Entities;
using TinyECommerce.Domain.Entities.Common;
using TinyECommerce.Domain.Enums;

namespace TinyECommerce.Persistence.Contexts;

public class TinyECommerceDbContext: DbContext
{
    public TinyECommerceDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var data = ChangeTracker.Entries<BaseEntity>();
        foreach (var datum in data)
        {
            // Set common fields each entity.
            datum.Entity.Status = DataStatus.Active;
            _ = datum.State switch
            {
                EntityState.Added => datum.Entity.CreatedAt = DateTime.UtcNow,
                EntityState.Modified => datum.Entity.UpdatedAt = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}