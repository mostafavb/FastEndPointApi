using FastEndpoints;
using MinimalApi.Application.DTOs.Products;
using MinimalApi.Application.Features.Products.Requests;
using MinimalApi.Application.Models;

namespace MinimalApi.FastEndpoins.Endpoints.Product;

public class InsertProductEndpoint : Endpoint<InsertProductRequest, BaseCommandResponse<ProductDto>>
{
    public override void Configure()
    {
        Post("/products");
        Description(x => x.WithName("CreateProduct"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(InsertProductRequest req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        if (response.Success)
            await SendAsync(response);
        else
            ThrowError($"{response.Message!}. {string.Join(" ", response.Errors)}");

    }
}
