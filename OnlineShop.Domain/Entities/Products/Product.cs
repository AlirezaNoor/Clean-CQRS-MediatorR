using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Categories;

namespace OnlineShop.Domain.Entities.Products;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public string  Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryRef { get; set; }
    public Category  Category { get; set; }
}