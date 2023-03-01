using Microsoft.EntityFrameworkCore;
using TinyECommerce.Domain.Entities.Common;

namespace TinyECommerce.Application.Repositories;

public interface IRepository<T> where T: BaseEntity
{
    DbSet<T> Table { get; }
}