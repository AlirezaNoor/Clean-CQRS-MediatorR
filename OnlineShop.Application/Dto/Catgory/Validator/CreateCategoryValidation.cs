using FluentValidation;

namespace OnlineShop.Application.Dto.Catgory.Validator;

public class CreateCategoryValidation:AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("فیلد مورد نظر نباید خالی باشد!ً");
        RuleFor(x => x.Des).MaximumLength(200).WithMessage("طول متن شما بیش از حد مجاز می باشد");
    }
}