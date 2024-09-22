using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto.Catgory;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Application.Feature.CategoryType.Request.Query;

namespace OnilneShop.Apis.Controllers.Catgeory;

public class CategoriesController : BaseControllers
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("Categories")]
    public async Task<IActionResult> GetAllCategory()
    {
        var result = await _mediator.Send(new GetAllCatgeoryRequest());

        return Ok(result);
    }

    [HttpGet("Category/{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var result = await _mediator.Send(new GetCategoryRequest() { Id = id });
        return Ok(result);
    }

    [HttpPost("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        var result = await _mediator.Send(new CreateCategoryRequest() { CreateCategoryDto = createCategoryDto });
        return Ok(result);
    }

    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        var result = await _mediator.Send(new UpdateCategoryRequest() { UpdateCategoryDto = updateCategoryDto });
        return Ok(result);
    }

    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var result = await _mediator.Send(new DeleteCategoryRequest() { Id = id });
        return Ok(result);
    }
}