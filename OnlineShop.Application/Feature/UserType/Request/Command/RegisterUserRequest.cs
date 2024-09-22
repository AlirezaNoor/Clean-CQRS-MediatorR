using MediatR;
using OnlineShop.Application.Dto.User;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.UserType.Request.Command;

public class RegisterUserRequest:IRequest<Result<bool>>
{
    public CreateUserDto CreateUserDto { get; set; }
}