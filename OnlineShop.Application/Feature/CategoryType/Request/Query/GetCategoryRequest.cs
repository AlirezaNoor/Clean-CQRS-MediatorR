using MediatR;
using OnlineShop.Application.Dto.Catgory;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities.Categories;

namespace OnlineShop.Application.Feature.CategoryType.Request.Query;

public class GetCategoryRequest:IRequest<Result<CategoryDto>>
{
    public int Id { get; set; }
}