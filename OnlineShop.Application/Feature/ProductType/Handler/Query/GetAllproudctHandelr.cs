using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Feature.ProductType.Request.Query;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IPersistence.Product;

namespace OnlineShop.Application.Feature.ProductType.Handler.Query;

public class GetAllproudctHandelr:IRequestHandler<GetAllproudctRequest,Result<List<ProductDto>>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllproudctHandelr(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<ProductDto>>> Handle(GetAllproudctRequest request, CancellationToken cancellationToken)
    {
        var Product = await _productRepository.GetAll();
        return Result<List<ProductDto>>.SuccessResult(_mapper.Map<List<ProductDto>>(Product));
    }
}