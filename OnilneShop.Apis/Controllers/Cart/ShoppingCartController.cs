using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto.Shoping;
using OnlineShop.Application.Feature.CartType.Request.Command;

namespace OnilneShop.Apis.Controllers.Cart;

public class ShoppingCartController:BaseControllers
{
    private readonly IMediator _mediator;

    public ShoppingCartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/shoppingcart/add
    [HttpPost("add")]
    public async Task<IActionResult> AddToCart([FromBody] AddTocartDto addTocartDto)
    {
      
        await _mediator.Send(new AddTocartRequest()
        {
            ProductId = addTocartDto.ProductId,
            Quantity = addTocartDto.Quantity,
            UserId = addTocartDto.Userid
        });
        return Ok("Item added to cart");
    }

    // POST api/shoppingcart/remove
    [HttpPut("remove")]
    public async Task<IActionResult> RemoveFromCart([FromBody] RemoveFromCartDto removeFromCartDto)
    {
         await _mediator.Send( new RemoveFromCartRequest()
         {
             Userid = removeFromCartDto.Userid,
             ProductId = removeFromCartDto.ProductId
         });
        return Ok("Item removed from cart");
    }
}