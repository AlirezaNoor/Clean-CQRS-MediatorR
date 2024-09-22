using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.IPersistence.Users;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Persistence.Users;

public class UserRepository:GenericRepository<User>,IUserRepository
{
    private readonly ShopDbContext _dbContext;
    public UserRepository(ShopDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CheckWithUserName(string username)
    {
        return await _dbContext.User.AnyAsync(x => x.UserName == username);
    }

    public async Task<User> GetWithUserName(string username)
    {
        return await _dbContext.User.FirstOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<bool> CheckUserExist(string id)
    {
        return await _dbContext.User.AnyAsync(x => x.Id.ToString() == id);
    }
}