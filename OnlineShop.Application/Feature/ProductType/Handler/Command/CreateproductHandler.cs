using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Dto.Product.Validator;
using OnlineShop.Application.Feature.ProductType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.IPersistence.Category;
using OnlineShop.Domain.IPersistence.Product;

namespace OnlineShop.Application.Feature.ProductType.Handler.Command;

public class CreateproductHandler:IRequestHandler<CreateproductRequest,Result<bool>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateproductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Result<bool>> Handle(CreateproductRequest request, CancellationToken cancellationToken)
    {
        CreateProductDtoValidation validation = new(_categoryRepository);

        var ProductIsvalid =await validation.ValidateAsync(request.ProductDto);

        if (!ProductIsvalid.IsValid)
        {
            return Result<bool>.ErrorResult(ProductIsvalid.Errors.Select(x => x.ErrorMessage).ToList());
        }
        
        // Product p=new Product()
        // {
        //     Id = request.ProductDto.Id,
        //     Name =request.ProductDto.Name,
        //     Category.....
        //     
        // }

        try
        {
            var productEntity = _mapper.Map<Product>(request.ProductDto);
            await _productRepository.Create(productEntity);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return Result<bool>.SuccessResult(true);

    }
}