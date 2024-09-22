using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.IPersistence;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Persistence;

public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity:class
{

    private readonly ShopDbContext _dbContext;

    public GenericRepository(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity> Get(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<IQueryable<TEntity>> GetAll()
    {
        return  _dbContext.Set<TEntity>().AsQueryable().AsNoTracking();
    }

    public async Task Create(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task update(TEntity entity)
    {
         _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
          _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}