using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Cart;
using OnlineShop.Domain.IPersistence.CartRepository;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Persistence.Cart;

public class shopingCartRepository : GenericRepository<ShopnigCart>, IshopingCartRepository
{
    private readonly ShopDbContext _dbContext;

    public shopingCartRepository(ShopDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ShopnigCart> CheckCartForUser(string userid)
    {
        return await _dbContext.ShopnigCarts.Include(x => x.item).ThenInclude(x => x.product)
            .FirstOrDefaultAsync(x => x.UserId == userid);
    }
}