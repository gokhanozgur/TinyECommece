using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence;

public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<TinyCommerceDbContext>
{
    public TinyCommerceDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<TinyCommerceDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.PostgreSqlConnectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}