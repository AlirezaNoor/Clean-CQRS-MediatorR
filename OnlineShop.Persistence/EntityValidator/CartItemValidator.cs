using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Cart;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Persistence.EntityValidator;

public class CartItemValidator:IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItem");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.product).WithMany().HasForeignKey(x => x.productId);
        builder.HasOne(x => x.ShopnigCart).WithMany(x => x.item).HasForeignKey(x => x.ShopingcartId);
        
    }
}