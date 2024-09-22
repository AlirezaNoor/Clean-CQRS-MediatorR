using MediatR;
using OnlineShop.Application.Dto.Catgory;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.CategoryType.Request.Command;

public class UpdateCategoryRequest:IRequest<Result<bool>>
{
    public UpdateCategoryDto UpdateCategoryDto { get; set; }    
}