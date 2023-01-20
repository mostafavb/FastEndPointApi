using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Application.Contracts.Interfaces;
using MinimalApi.Data.Repositories;

namespace MinimalApi.Data;
public static class DataServiceConfiguration
{
    public static void DataServicesRegistreration(this IServiceCollection services)
    {
        services.AddSingleton<IProductService, ProductService>();
    }
}
