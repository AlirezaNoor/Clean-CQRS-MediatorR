using FluentValidation;
using MediatR;
using OnlineShop.Application.Dto.Catgory.Validator;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities.Categories;
using OnlineShop.Domain.IPersistence.Category;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Command;

public class CreateCategoryHandler:IRequestHandler<CreateCategoryRequest,Result<string>>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<string>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        CreateCategoryValidation validation = new CreateCategoryValidation();
        var CreateCategoryValidator = await validation.ValidateAsync(request.CreateCategoryDto);
        if (!CreateCategoryValidator.IsValid)
        {
            return Result<string>.ErrorResult(CreateCategoryValidator.Errors.Select(x => x.ErrorMessage).ToList());
        }
        Category category = new Category()
        {
            Name = request.CreateCategoryDto.Name,
            Des = request.CreateCategoryDto.Des
        };
        await _categoryRepository.Create(category);
        return Result<string>.SuccessResult("عملیات با موفقیا انجام شد", "دسته بندی ساخته شد!");
    }
}