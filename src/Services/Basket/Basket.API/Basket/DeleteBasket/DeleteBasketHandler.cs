using System.Data;
using Basket.API.Data;
using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : IRequest<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketValidator()
    {
        RuleFor(x => x.UserName).NotNull().WithMessage("UserName is required");
    } 
}

internal class DeleteBasketHandler(IBasketReponsitory reponsitory) : ICommandHandler<DeleteBasketCommand,DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //Todo: Update db
        await reponsitory.DeleteBasket(command.UserName, cancellationToken);
        //Todo: Update redis
        return new DeleteBasketResult(true);
    }
}