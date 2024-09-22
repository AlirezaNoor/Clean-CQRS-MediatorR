using MediatR;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IPersistence.Category;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Command;

public class DeleteCategoryHandler:IRequestHandler<DeleteCategoryRequest,Result<string>>
{

    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<string>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var Entity = await _categoryRepository.Get(request.Id);

        if (Entity==null)
        {
            return Result<string>.ErrorResult("دسته بندی مورد نظر یافت نشد");
        }

        await _categoryRepository.Delete(Entity);
        return Result<string>.SuccessResult("دسته بندی حذف شد","عملیات انجام شد");
    }
}