using MediatR;
using OnlineShop.Application.Dto.User;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.UserType.Request.Query;

public class LoginUserRequest:IRequest<Result<string>>
{
    public UserDto userDto { get; set; }
}