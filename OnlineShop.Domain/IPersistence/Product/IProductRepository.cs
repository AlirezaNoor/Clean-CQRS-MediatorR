namespace OnlineShop.Domain.IPersistence.Product;

public interface IProductRepository:IGenericRepository<Entities.Products.Product>
{
    Task<bool> CheckPropductExist(int id);
}