namespace OnlineShop.Domain.IPersistence;

public interface IGenericRepository<TEntity> where TEntity :class
{
    Task<TEntity> Get(int id);
    Task<IQueryable<TEntity>> GetAll();
    Task Create(TEntity entity);
    Task update(TEntity entity);
    Task Delete(TEntity entity);
}