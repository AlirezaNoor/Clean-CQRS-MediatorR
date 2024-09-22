namespace OnlineShop.Application.Dto.User;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string password { get; set; }
}