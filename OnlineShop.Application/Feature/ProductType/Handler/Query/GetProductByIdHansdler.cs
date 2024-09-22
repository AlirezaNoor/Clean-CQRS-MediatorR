using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Feature.ProductType.Request.Query;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IPersistence.Product;

namespace OnlineShop.Application.Feature.ProductType.Handler.Query;

public class GetProductByIdHansdler : IRequestHandler<GetProductByIdRequest, Result<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdHansdler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Result<ProductDto>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var porduct = await _productRepository.Get(request.id);
        return Result<ProductDto>.SuccessResult(_mapper.Map<ProductDto>(porduct));
        
    }
}