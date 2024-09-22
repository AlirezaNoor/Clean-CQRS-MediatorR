namespace OnlineShop.Domain.IPersistence.Category;

public interface ICategoryRepository:IGenericRepository<Entities.Categories.Category>
{
     
    Task<string> GetCategoryname(int id);

    Task<bool> CheckExistCatgery(int id);
}