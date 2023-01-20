namespace MinimalApi.Application.Features.Products.Requests;
public class InsertProductDto
{
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
