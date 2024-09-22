using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto.User;
using OnlineShop.Application.Feature.UserType.Request.Command;
using OnlineShop.Application.Feature.UserType.Request.Query;

namespace OnilneShop.Apis.Controllers.User;

public class UserController : BaseControllers
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("registeruser")]
    public async Task<IActionResult> Register(CreateUserDto dto)
    {
        var result = await _mediator.Send(new RegisterUserRequest() { CreateUserDto = dto });
        return Ok(result);
    }

    [HttpPost("userlogin")]
    public async Task<IActionResult> Login(UserDto dto)
    {
        var result = await _mediator.Send(new LoginUserRequest() { userDto = dto });
        return Ok(result);
    }
}