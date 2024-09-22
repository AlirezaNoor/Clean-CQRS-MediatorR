using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Categories;

namespace OnlineShop.Persistence.EntityValidator;

public class CategoryValidator:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(15);
        builder.Property(x => x.Des).HasMaxLength(200);
    }
}