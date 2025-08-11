using Application.Dto;
using AutoMapper;
using Domain.Models.Products;
using Domain.Models.Users;

namespace Application.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
    } 
}