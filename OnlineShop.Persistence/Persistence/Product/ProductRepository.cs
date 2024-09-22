using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.IPersistence.Product;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Persistence.Product;

public class ProductRepository:GenericRepository<Domain.Entities.Products.Product>,IProductRepository
{
    private readonly ShopDbContext _dbContext;
    public ProductRepository(ShopDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CheckPropductExist(int id)
    {
        return await _dbContext.Products.AnyAsync(x => x.Id == id);
    }
}