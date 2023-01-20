using MinimalApi.Domain.Entities.Common;

namespace MinimalApi.Domain.Entities;
public class Product : BaseDomain<Guid>
{
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
