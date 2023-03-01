using TinyECommerce.Domain.Entities.Common;

namespace TinyECommerce.Domain.Entities;

public class Customer: BaseEntity
{
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}