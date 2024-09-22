using OnlineShop.Domain.Cart;

namespace OnlineShop.Domain.IPersistence.CartRepository;

public interface IshopingCartRepository:IGenericRepository<ShopnigCart>
{

    Task<ShopnigCart> CheckCartForUser(string userid);
}