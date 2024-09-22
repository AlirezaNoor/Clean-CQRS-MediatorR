using MediatR;
using OnlineShop.Application.Feature.CartType.Request.Command;
using OnlineShop.Domain.IPersistence.CartRepository;
using OnlineShop.Domain.IPersistence.Product;

namespace OnlineShop.Application.Feature.CartType.Handler.Command;

public class RemoveFromCartHandler:IRequestHandler<RemoveFromCartRequest>
{

    private readonly IshopingCartRepository _shopingCartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;

    public RemoveFromCartHandler(IshopingCartRepository shopingCartRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
    {
        _shopingCartRepository = shopingCartRepository;
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(RemoveFromCartRequest request, CancellationToken cancellationToken)
    {
        var cart = await _shopingCartRepository.CheckCartForUser(request.Userid);

        if (cart==null)
        {
            throw new Exception("CartnotFound!");
        }

        var cartitem = cart.item.FirstOrDefault(x => x.productId == request.ProductId);

        if (cartitem!=null)
        {
            cart.item.Remove(cartitem);
        }

        await _shopingCartRepository.update(cart);

        return Unit.Value;
    }
}