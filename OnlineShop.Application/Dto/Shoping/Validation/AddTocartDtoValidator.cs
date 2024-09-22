using FluentValidation;
using OnlineShop.Domain.IPersistence.Product;
using OnlineShop.Domain.IPersistence.Users;

namespace OnlineShop.Application.Dto.Shoping.Validation;

public class AddTocartDtoValidator:AbstractValidator<AddTocartDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    public AddTocartDtoValidator(IProductRepository productRepository, IUserRepository userRepository)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
        RuleFor(x => x.ProductId).MustAsync((id, token) =>
        {
           return _productRepository.CheckPropductExist(id);
        }).WithMessage("این کالا موجود نمی باشد");
        
        RuleFor(x => x.Userid).MustAsync((id, token) =>
        {
            return _userRepository.CheckUserExist(id);
        }).WithMessage("این کالا موجود نمی باشد");
    }
}