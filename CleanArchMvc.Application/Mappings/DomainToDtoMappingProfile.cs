using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Dtos;

namespace CleanArchMvc.Application.Mappings;

public class DomainToDtoMappingProfile: Profile
{
	public DomainToDtoMappingProfile()
	{
		CreateMap<Category, CategoryDto>().ReverseMap();
		CreateMap<Product, ProductDto>().ReverseMap();
	}
}
