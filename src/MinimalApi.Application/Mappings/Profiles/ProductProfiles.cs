using AutoMapper;
using MinimalApi.Application.DTOs.Products;
using MinimalApi.Application.Features.Products.Requests;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Application.Mappings.Profiles;
public class ProductProfiles : Profile
{
	public ProductProfiles()
	{
		CreateMap<Product, InsertProductDto>().ReverseMap();
		CreateMap<Product, ProductDto>().ReverseMap();
	}
}
