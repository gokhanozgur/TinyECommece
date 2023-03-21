using TinyECommerce.Domain.Enums;

namespace TinyECommerce.Domain.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; set; }

    public DataStatus Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}