using MediatR;
using OnlineShop.Application.Dto.Catgory;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.CategoryType.Request.Command;

public class CreateCategoryRequest:IRequest<Result<string>>
{
    public CreateCategoryDto CreateCategoryDto { get; set; }
}