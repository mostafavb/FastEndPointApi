using MinimalApi.Domain.Entities;

namespace MinimalApi.Application.Contracts.Interfaces;
public interface IProductService
{
    List<Product> Products { get; set; }

    Task Delete(string name);
    Product? Get(string name);
    Task<List<Product>> GetAll();
    Task<Product> Insert(Product insertProduct);
}