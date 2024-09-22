using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Feature.UserType.Request.Query;
using OnlineShop.Common.PasswordHasher;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IPersistence.Users;

namespace OnlineShop.Application.Feature.UserType.Handler.Query;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, Result<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public LoginUserHandler(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<Result<string>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetWithUserName(request.userDto.UserName);

        if (user == null)
        {
            return Result<string>.ErrorResult("Error!");
        }

        var userpassword = request.userDto.password.Hashpassword(user.Salt);

        if (user.password != userpassword)
        {
            return Result<string>.ErrorResult("Error!");
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.userDto.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
        };
        var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:Key"]));
        var Card = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: Card
        );
        return Result<string>.SuccessResult(new JwtSecurityTokenHandler().WriteToken(token).ToString());
    }
}