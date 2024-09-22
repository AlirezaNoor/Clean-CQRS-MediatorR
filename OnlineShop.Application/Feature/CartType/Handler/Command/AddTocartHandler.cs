using MediatR;
using OnlineShop.Application.Feature.CartType.Request.Command;
using OnlineShop.Domain.Cart;
using OnlineShop.Domain.IPersistence.CartRepository;
using OnlineShop.Domain.IPersistence.Product;

namespace OnlineShop.Application.Feature.CartType.Handler.Command;

public class AddTocartHandler:IRequestHandler<AddTocartRequest>
{

    private readonly IshopingCartRepository _shopingCartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;

    public AddTocartHandler(IshopingCartRepository shopingCartRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
    {
        _shopingCartRepository = shopingCartRepository;
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(AddTocartRequest request, CancellationToken cancellationToken)
    {
        var cart =  await _shopingCartRepository.CheckCartForUser(request.UserId);

        if (cart==null)
        {
            cart = new ShopnigCart()
            {
                UserId = request.UserId,
                item = new List<CartItem>()
            };
        }

        var product = await _productRepository.Get(request.ProductId);
        if (product==null)
        {
            throw new Exception("product not found!");
        }

        var cartitem = cart.item.FirstOrDefault(x => x.productId == request.ProductId);

        if (cartitem==null)
        {
            cartitem = new CartItem()
            {
                productId = request.ProductId,
                Quantity = request.Quantity,
                product = product
            };
            cart.item.Add(cartitem);
        }

        else
        {
            cartitem.Quantity += request.Quantity;
        }

        await _shopingCartRepository.Create(cart);

        return Unit.Value;
    }
}