using FastEndpoints;
using MinimalApi.Application.Contracts.Interfaces;
using MinimalApi.Application.DTOs.Products;
using MinimalApi.Application.Features.Products.Requests;

namespace MinimalApi.Application.Features.Products.Handlers;
public class GetAllProductHandler : ICommandHandler<GetAllProductRequest, List<ProductDto>>
{
    private readonly IProductService _productService;
    private readonly AutoMapper.IMapper _mapper;

    public GetAllProductHandler(IProductService productService, AutoMapper.IMapper mapper)
    {
        this._productService = productService;
        this._mapper = mapper;
    }

    public async Task<List<ProductDto>> ExecuteAsync(GetAllProductRequest command, CancellationToken ct = default)
    {
        var products = await _productService.GetAll();
        return _mapper.Map<List<ProductDto>>(products);
    }
}
