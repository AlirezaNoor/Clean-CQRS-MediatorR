using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.IPersistence.CartRepository;
using OnlineShop.Domain.IPersistence.Category;
using OnlineShop.Domain.IPersistence.Product;
using OnlineShop.Domain.IPersistence.Users;
using OnlineShop.Persistence.Context;
using OnlineShop.Persistence.Persistence.Cart;
using OnlineShop.Persistence.Persistence.Category;
using OnlineShop.Persistence.Persistence.Product;
using OnlineShop.Persistence.Persistence.Users;

namespace OnlineShop.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection PersistenceConfiguration(this IServiceCollection Service, IConfiguration cofig)
    {
        Service.AddScoped<ICategoryRepository, CategoryRepository>();
        Service.AddScoped<IProductRepository, ProductRepository>();
        Service.AddScoped<IUserRepository, UserRepository>();
        Service.AddScoped<ICartItemRepository, CartItemRepository>();
        Service.AddScoped<IshopingCartRepository, shopingCartRepository>();
        Service.AddDbContext<ShopDbContext>(opt => opt.UseNpgsql(cofig.GetConnectionString("OnlineShop")));

        return Service;
    }
}