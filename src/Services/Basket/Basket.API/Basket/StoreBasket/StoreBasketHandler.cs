using Basket.API.Data;
using Basket.API.Models;
using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

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

internal class StoreBasketCommandHandler(IBasketReponsitory reponsitory) : ICommandHandler<StoreBasketCommand,StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;
        //Todo: Create/Update DB
        await reponsitory.StoreBasket(cart,cancellationToken);
        //Todo: Update redis

        return new StoreBasketResult(true);
    }
}