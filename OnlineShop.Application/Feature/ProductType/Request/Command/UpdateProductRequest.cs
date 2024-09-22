using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Common.ResultPattern;

namespace OnlineShop.Application.Feature.ProductType.Request.Command;

public class UpdateProductRequest:IRequest<Result<bool>>
{
    public UpdateProductDto UpdateProductDto { get; set; }
}