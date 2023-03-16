using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TinyECommerce.Application.Repositories;
using TinyECommerce.Domain.Entities.Common;
using TinyECommerce.Persistence.Contexts;

namespace TinyECommerce.Persistence.Repositories;

public class ReadRepository<T>: IReadRepository<T> where T: BaseEntity
{
    private readonly TinyECommerceDbContext _context;

    public ReadRepository(TinyECommerceDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = tracking ? Table.AsQueryable() : Table.AsNoTracking();
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        query = tracking ? Table.AsQueryable() : Table.AsNoTracking();
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = tracking ? Table.AsQueryable() : Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }

    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    {
        var query = tracking ? Table.AsQueryable() : Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }
}