using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Cart;

public class ShopnigCart:BaseEntity
{
    public string UserId { get; set; }
    public List<CartItem> item { get; set; } = new List<CartItem>();
    public Decimal Totalprice
    {
        get
        {
            return item.Sum(x => x.product.Price * x.Quantity);
        }
    }
}