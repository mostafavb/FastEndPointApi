using FastEndpoints;
using MinimalApi.Application.DTOs.Products;
using MinimalApi.Application.Features.Products.Requests;

namespace MinimalApi.FastEndpoins.Endpoints.Product;

//[HttpGet("/products"),AllowAnonymous]
public class GetAllProductsEndpoint : Endpoint<GetAllProductRequest, List<ProductDto>>
{
    public override void Configure()
    {
        Get("/products");
        Description(x => x.WithName("GetAllProducts"));
        AllowAnonymous();
    }
    
    public async override Task HandleAsync(GetAllProductRequest req, CancellationToken ct)
    {
        await SendAsync(await req.ExecuteAsync(ct));
    }
}
