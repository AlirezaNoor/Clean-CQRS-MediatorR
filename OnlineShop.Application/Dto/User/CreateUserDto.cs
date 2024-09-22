namespace OnlineShop.Application.Dto.User;

public class CreateUserDto
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string password { get; set; }
    public string Salt { get; set; }
}