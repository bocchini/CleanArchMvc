using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings;

public class DtoToMappingProfile: Profile
{
    public DtoToMappingProfile()
    {
        CreateMap<ProductDto, ProductCreateCommand>();
        CreateMap<ProductDto, ProductUpdateCommand>();
    }
}
