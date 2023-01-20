using FastEndpoints;
using MinimalApi.Application.DTOs.Products;
using MinimalApi.Application.Models;

namespace MinimalApi.Application.Features.Products.Requests;
public class InsertProductRequest : ICommand<BaseCommandResponse<ProductDto>>
{
    public InsertProductDto? InsertProductDto{ get; set; }
}
