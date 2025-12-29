namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : IRequest<StoreBasketResult>;
public record StoreBasketResult(bool IsSuccess);


public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart is required");
        RuleFor(x => x.Cart.UserName).NotNull().WithMessage("UserName is required");
    }
}

internal class StoreBasketCommandHandler(IBasketReponsitory reponsitory,
    DiscountProtoService.DiscountProtoServiceClient discountProtoService
) : ICommandHandler<StoreBasketCommand,StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;
        await DeductDiscount(cart, cancellationToken);
        await reponsitory.StoreBasket(cart,cancellationToken);

        return new StoreBasketResult(true);
    }

    public async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        foreach (var item in cart.Items)
        {
            var coupon = await discountProtoService.GetDiscountAsync(new GetDiscountRequest
                { ProductName = item.ProductName }, cancellationToken:  cancellationToken);
            item.Price -= coupon.Amount;
        }
    }
}