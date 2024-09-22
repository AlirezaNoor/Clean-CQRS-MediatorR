using MediatR;
using OnlineShop.Application.Dto.Catgory;
using OnlineShop.Application.Feature.CategoryType.Request.Query;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities.Categories;
using OnlineShop.Domain.IPersistence.Category;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Query;

public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, Result<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<CategoryDto>> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var Catgeory = await _categoryRepository.Get(request.Id);
        if (Catgeory==null)
        {
            return Result<CategoryDto>.ErrorResult("دسته بندی موجود نیست!");
        }

        CategoryDto categoryDto = new CategoryDto()
        {
            Name = Catgeory.Name,
            Des = Catgeory.Des,
            Id = Catgeory.Id
        };
  
        return Result<CategoryDto>.SuccessResult(categoryDto, "عملیات با موفقیت انجام شد!");
    }
}