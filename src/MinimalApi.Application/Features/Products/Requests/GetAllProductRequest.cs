using FastEndpoints;
using MinimalApi.Application.DTOs.Products;

namespace MinimalApi.Application.Features.Products.Requests;
public class GetAllProductRequest : ICommand<List<ProductDto>>
{
}
