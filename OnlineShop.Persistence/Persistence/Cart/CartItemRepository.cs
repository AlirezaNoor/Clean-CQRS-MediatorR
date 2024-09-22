using OnlineShop.Domain.Cart;
using OnlineShop.Domain.IPersistence.CartRepository;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Persistence.Cart;

public class CartItemRepository:GenericRepository<CartItem>,ICartItemRepository
{
    public CartItemRepository(ShopDbContext dbContext) : base(dbContext)
    {
    }
}