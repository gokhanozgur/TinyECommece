using TinyECommerce.Domain.Entities.Common;

namespace TinyECommerce.Domain.Entities;

public class Product: BaseEntity
{
    public string Name { get; set; }

    public int Stock { get; set; }

    public long Price { get; set; }
}