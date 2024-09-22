using MediatR;

namespace OnlineShop.Application.Feature.CartType.Request.Command;

public class AddTocartRequest:IRequest
{
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public int  Quantity { get; set; }
}