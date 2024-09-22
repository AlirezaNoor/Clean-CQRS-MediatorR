namespace OnlineShop.Domain.Entities.Users;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string password { get; set; }
    
    public string Salt { get; set; }

    public User()
    {
        Id = Guid.NewGuid();
    }
}