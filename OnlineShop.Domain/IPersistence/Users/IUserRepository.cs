using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Domain.IPersistence.Users;

public interface IUserRepository:IGenericRepository<User>
{
    Task<bool> CheckWithUserName(string username);
    Task<User> GetWithUserName(string username);
    Task<bool> CheckUserExist(string id);

}