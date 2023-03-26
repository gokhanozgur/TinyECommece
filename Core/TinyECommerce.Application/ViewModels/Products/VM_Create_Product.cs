using TinyECommerce.Domain.Entities.Common;

namespace TinyECommerce.Application.ViewModels.Products;

public class VM_Create_Product
{
    public string Name { get; set; }

    public int Stock { get; set; }

    public float Price { get; set; }
}