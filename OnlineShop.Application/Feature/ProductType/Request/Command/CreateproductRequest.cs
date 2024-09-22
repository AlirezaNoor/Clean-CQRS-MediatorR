using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.ProductType.Request.Command;

public class CreateproductRequest:IRequest<Result<bool>>
{
    public CreateProductDto ProductDto { get; set; }
}