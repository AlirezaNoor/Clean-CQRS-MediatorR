using OnlineShop.Application.Dto.Common;

namespace OnlineShop.Application.Dto.Product;

public class UpdateProductDto:BaseDto
{
    public string Name { get; set; }
    public string  Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryRef { get; set; }
}