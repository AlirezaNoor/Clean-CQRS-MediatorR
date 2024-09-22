using MediatR;
using OnlineShop.Application.Dto.Catgory;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.CategoryType.Request.Query;

public class GetAllCatgeoryRequest:IRequest<Result<IQueryable<CategoryDto>>>
{
    
}