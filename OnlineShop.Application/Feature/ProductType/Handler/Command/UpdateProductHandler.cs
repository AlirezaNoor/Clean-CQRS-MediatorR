using AutoMapper;
using FluentValidation;
using MediatR;
using OnlineShop.Application.Dto.Product.Validator;
using OnlineShop.Application.Feature.ProductType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IPersistence.Category;
using OnlineShop.Domain.IPersistence.Product;

namespace OnlineShop.Application.Feature.ProductType.Handler.Command;

public class UpdateProductHandler:IRequestHandler<UpdateProductRequest,Result<bool>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Result<bool>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        UpdateProductDtovalidation dtovalidation = new(_categoryRepository);
        var updateProuctdtoisvalidate = await dtovalidation.ValidateAsync(request.UpdateProductDto);
        if (!updateProuctdtoisvalidate.IsValid)
        {
            return Result<bool>.ErrorResult(updateProuctdtoisvalidate.Errors.Select(x => x.ErrorMessage).ToList());
        }
        
        var ProductEntity = await _productRepository.Get(request.UpdateProductDto.Id);

        if (ProductEntity==null)
        {
            return Result<bool>.ErrorResult("همچین کالایی موجود نمی باشد!");
        }

        var Updateproduct = _mapper.Map(request.UpdateProductDto, ProductEntity);

        await _productRepository.update(ProductEntity);
        return Result<bool>.SuccessResult(true);

    }

}