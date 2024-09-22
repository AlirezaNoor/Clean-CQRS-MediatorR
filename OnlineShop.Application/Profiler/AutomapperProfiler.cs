using AutoMapper;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Dto.User;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Application.Profiler;

public class AutomapperProfiler:Profile
{
    public AutomapperProfiler()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}