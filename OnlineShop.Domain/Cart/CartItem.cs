using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Domain.Cart;

public class CartItem:BaseEntity
{
    public int productId { get; set; }
    public int Quantity { get; set; }

    public int  ShopingcartId { get; set; }
    public Product product { get; set; }
    public ShopnigCart ShopnigCart { get; set; }
}