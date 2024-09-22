using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.ProductType.Request.Query;

public class GetProductByIdRequest:IRequest<Result<ProductDto>>
{
    public int  id { get; set; }
}