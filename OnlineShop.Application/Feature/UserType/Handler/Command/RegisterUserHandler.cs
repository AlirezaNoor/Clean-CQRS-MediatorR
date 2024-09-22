using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto.User.Validation;
using OnlineShop.Application.Feature.UserType.Request.Command;
using OnlineShop.Common.PasswordHasher;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.IPersistence.Users;

namespace OnlineShop.Application.Feature.UserType.Handler.Command;

public class RegisterUserHandler:IRequestHandler<RegisterUserRequest,Result<bool>>
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RegisterUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<bool>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        CreateUserDtoValidation validation = new CreateUserDtoValidation(_userRepository);
        var userisvalid = await validation.ValidateAsync(request.CreateUserDto);

        if (!userisvalid.IsValid)
        {
            return Result<bool>.ErrorResult(userisvalid.Errors.Select(x => x.ErrorMessage).ToList());
        }

        var userEntity = _mapper.Map<User>(request.CreateUserDto);

        var salt = PasswordHashExtension.GenerateSalt();

        userEntity.password= userEntity.password.Hashpassword(salt);
        userEntity.Salt = salt;
        await _userRepository.Create(userEntity);
        return Result<bool>.SuccessResult(true);

    }
}