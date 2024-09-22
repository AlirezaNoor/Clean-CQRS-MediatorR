using MediatR;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.CategoryType.Request.Command;

public class DeleteCategoryRequest:IRequest<Result<string>>
{
    public int Id { get; set; }
}