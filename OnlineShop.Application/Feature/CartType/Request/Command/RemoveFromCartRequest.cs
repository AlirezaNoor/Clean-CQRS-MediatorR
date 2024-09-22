using MediatR;

namespace OnlineShop.Application.Feature.CartType.Request.Command;

public class RemoveFromCartRequest:IRequest
{
    public string Userid { get; set; }
    public int ProductId { get; set; }
}