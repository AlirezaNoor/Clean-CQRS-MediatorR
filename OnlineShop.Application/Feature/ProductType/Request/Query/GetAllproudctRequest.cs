using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.ProductType.Request.Query;

public class GetAllproudctRequest:IRequest<Result<List<ProductDto>>>
{
    
}