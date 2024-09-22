using FluentValidation;
using OnlineShop.Domain.IPersistence.Category;

namespace OnlineShop.Application.Dto.Product.Validator;

public class UpdateProductDtovalidation:AbstractValidator<UpdateProductDto>
{

    private readonly ICategoryRepository _categoryRepository;

    public UpdateProductDtovalidation(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(x => x.Name).NotEmpty().WithName("فیلد نام را پرکنید!")
            .MaximumLength(150).WithMessage("طول عبارت بیشتر از حد مجاز است");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("طول عبارت بییشتر از صفر نیست!");

        RuleFor(x => x.CategoryRef).MustAsync(async (cref, t) =>
        {
            return await _categoryRepository.CheckExistCatgery(cref);
        }).WithMessage("دسته بندی مورد نظر وجود ندارد!");
    }
}