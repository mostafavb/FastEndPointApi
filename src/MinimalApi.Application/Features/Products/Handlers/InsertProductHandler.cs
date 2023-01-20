using FastEndpoints;
using Microsoft.Extensions.Logging;
using MinimalApi.Application.Contracts.Interfaces;
using MinimalApi.Application.DTOs.Products;
using MinimalApi.Application.Features.Products.Requests;
using MinimalApi.Application.Models;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Application.Features.Products.Handlers;
public class InsertProductHandler : ICommandHandler<InsertProductRequest, BaseCommandResponse<ProductDto>>
{
    private readonly IProductService _service;
    private readonly AutoMapper.IMapper _mapper;
    private readonly ILogger _logger;

    public InsertProductHandler(IProductService service, AutoMapper.IMapper mapper, ILogger<InsertProductHandler> logger)
    {
        _service = service;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseCommandResponse<ProductDto>> ExecuteAsync(InsertProductRequest command, CancellationToken ct = default)
    {
        var response = new BaseCommandResponse<ProductDto>();
        try
        {
            var entityProduct = _mapper.Map<Product>(command.InsertProductDto);
            //throw new Exception("Vay che bad!");
            response.ReturnValue = _mapper.Map<ProductDto>(await _service.Insert(entityProduct));
        }
        catch (Exception ex)
        {
            var message = $"There is problem in creating product in {nameof(ExecuteAsync)}";
            _logger.LogError(ex, message);
            response.Success = false;
            response.Message = message;
            response.Errors!.Add(ex.Message);
        }
        return response;
    }

}