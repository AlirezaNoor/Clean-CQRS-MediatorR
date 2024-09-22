using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.IPersistence.Category;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Persistence.Category;

public class CategoryRepository:GenericRepository<Domain.Entities.Categories.Category>,ICategoryRepository
{
    private readonly ShopDbContext _dbContext;
    public CategoryRepository(ShopDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

 

    public async Task<string> GetCategoryname(int id)
    {
        var catgeoryName =   _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id).Result.Name;
        return catgeoryName;
    }

    public async Task<bool> CheckExistCatgery(int id)
    {
        return await _dbContext.Categories.AnyAsync(x => x.Id == id);
    }
}