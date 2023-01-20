using MinimalApi.Application.Contracts.Contracts.Infrastructure;
using MinimalApi.Application.Contracts.Interfaces;
using MinimalApi.Application.Models;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Data.Repositories;

public class ProductService : IProductService
{
    private readonly IEmailSender _emailSender;

    public ProductService(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }
    public List<Product> Products { get; set; } = new();

    public Task Delete(string name)
    {
        var product = Products.FirstOrDefault(f => f.Name == name);
        Products.Remove(product!);
        return Task.CompletedTask;
    }

    public Product? Get(string name) =>
        Products.FirstOrDefault(f => f.Name == name);

    public Task<List<Product>> GetAll() =>
        Task.Run(() => Products.ToList());

    public async Task<Product> Insert(Product insertProduct)
    {
        insertProduct.Id = Guid.NewGuid();
        Products.Add(insertProduct);

        var email = new Email
        {
            Body = $"{insertProduct.Description}",
            Subject = $"{insertProduct.Name}",
            To = "mvb@gmail.com"
        };

        //var emailSended = await _emailSender.SendEmail(email);

        return await Task.FromResult(insertProduct);
    }
}