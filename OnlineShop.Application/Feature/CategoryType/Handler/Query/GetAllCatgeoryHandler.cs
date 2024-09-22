using MediatR;
using OnlineShop.Application.Dto.Catgory;
using OnlineShop.Application.Feature.CategoryType.Request.Query;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IPersistence.Category;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Query;

public class GetAllCatgeoryHandler:IRequestHandler<GetAllCatgeoryRequest,Result<IQueryable<CategoryDto>>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCatgeoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<IQueryable<CategoryDto>>> Handle(GetAllCatgeoryRequest request, CancellationToken cancellationToken)
    {
        var Categoreis = await _categoryRepository.GetAll();
        var categoriesDto = Categoreis.Select(x => new CategoryDto()
        {
            Name = x.Name,
            Des = x.Des,
            Id = x.Id
        });

        return Result<IQueryable<CategoryDto>>.SuccessResult(categoriesDto, "عملیات با موفقیت انجام شد!");


    }
}