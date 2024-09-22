using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Cart;

namespace OnlineShop.Persistence.EntityValidator;

public class ShopingCartValidator : IEntityTypeConfiguration<ShopnigCart>
{
    public void Configure(EntityTypeBuilder<ShopnigCart> builder)
    {
        builder.ToTable("ShopingCart");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.item)
            .WithOne(x => x.ShopnigCart).HasForeignKey(x => x.ShopingcartId);
        
    }
}