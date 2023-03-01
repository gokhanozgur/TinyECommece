using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence;

public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<TinyECommerceDbContext>
{
    public TinyECommerceDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<TinyECommerceDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.PostgreSqlConnectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}