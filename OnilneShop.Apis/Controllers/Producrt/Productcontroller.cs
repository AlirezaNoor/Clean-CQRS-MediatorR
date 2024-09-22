using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Feature.ProductType.Request.Command;
using OnlineShop.Application.Feature.ProductType.Request.Query;

namespace OnilneShop.Apis.Controllers.Producrt;

public class Productcontroller : BaseControllers
{
    private readonly IMediator _mediator;

    public Productcontroller(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("createProduct")]
    public async Task<IActionResult> CreateProdutc(CreateProductDto dto)
    {
        var result = await _mediator.Send(new CreateproductRequest() { ProductDto = dto });
        return Ok(result);
    }

    [HttpPut("updateProduct")]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
    {
        var Result = await _mediator.Send(new UpdateProductRequest() { UpdateProductDto = dto });
        return Ok(Result);
    }

    // [HttpDelete("deleteproduct/{id}")]
    // public async Task<IActionResult> DeleteProduct(int id)
    // {
    //     var Result=await _mediator.Send(new DeletePro)
    // }

    [HttpGet("Products")]
    public async Task<IActionResult> GetAll()
    {
        var Result = await _mediator.Send(new GetAllproudctRequest());
        return Ok(Result);
    }

    [HttpGet("product/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var Result = await _mediator.Send(new GetProductByIdRequest() { id = id });
        return Ok(Result);
    }
}