using MediatR;
using OnlineShop.Application.Dto.Catgory.Validator;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IPersistence.Category;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Command;

public class UpdateCategoryHandler:IRequestHandler<UpdateCategoryRequest,Result<bool>>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<bool>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        UpdateCategoryDtoValidation validation = new UpdateCategoryDtoValidation();
        var CategoryisVaild = await validation.ValidateAsync(request.UpdateCategoryDto);
        if (!CategoryisVaild.IsValid)
        {
            return Result<bool>.ErrorResult(CategoryisVaild.Errors.Select(x=>x.ErrorMessage).ToList());
        }
        
        var Entity = await _categoryRepository.Get(request.UpdateCategoryDto.Id);

        Entity.Name = request.UpdateCategoryDto.Name;
        Entity.Des = request.UpdateCategoryDto.Des;

        await _categoryRepository.update(Entity);

        return Result<bool>.SuccessResult(true,"عملیات با موفقیت انجام شد!");
    }
}