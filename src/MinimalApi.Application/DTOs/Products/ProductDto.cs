namespace MinimalApi.Application.DTOs.Products;
public class ProductDto : BaseDto<Guid>
{    
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
