using FluentValidation;
using OnlineShop.Domain.IPersistence.Category;

namespace OnlineShop.Application.Dto.Product.Validator;

public class CreateProductDtoValidation:AbstractValidator<CreateProductDto>
{
    private ICategoryRepository _categoryRepository;
    public CreateProductDtoValidation(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        RuleFor(x => x.Name).NotEmpty().WithMessage("فیلد نام را پرکنید!").MaximumLength(150)
            .WithMessage("طول عبارت بیشتر از حد مجاز است! ");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("طول عبارت بییشتر از صفر نیست!");
        RuleFor(x => x.CategoryRef).MustAsync(async (cref, Token) =>
        {
            var result = await _categoryRepository.CheckExistCatgery(cref);
            return result;
        }).WithMessage("دسته مورد نظر موجود نمی باشد!");
    }
}