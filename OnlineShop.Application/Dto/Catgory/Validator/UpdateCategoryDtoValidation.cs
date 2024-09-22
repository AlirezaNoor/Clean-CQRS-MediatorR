using FluentValidation;

namespace OnlineShop.Application.Dto.Catgory.Validator;

public class UpdateCategoryDtoValidation:AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidation()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("شناسه موجود نیست!");
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("نام دسته بندی نباید خالی باشد!");
        RuleFor(x => x.Des).MaximumLength(200).WithMessage("طول متن شما بیش از حد مجاز می باشد");
    }
}