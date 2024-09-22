using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Cart;
using OnlineShop.Domain.Entities.Categories;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Persistence.EntityValidator;

namespace OnlineShop.Persistence.Context;

public class ShopDbContext:DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<ShopnigCart> ShopnigCarts { get; set; }
    public DbSet<User> User { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CategoryValidator());
        modelBuilder.ApplyConfiguration(new ProductValidator());
        modelBuilder.ApplyConfiguration(new UserValidator());
        modelBuilder.ApplyConfiguration(new CartItemValidator());
        modelBuilder.ApplyConfiguration(new ShopingCartValidator());
    }
}