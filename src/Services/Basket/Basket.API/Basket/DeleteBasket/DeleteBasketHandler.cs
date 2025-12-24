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

        await reponsitory.DeleteBasket(command.UserName, cancellationToken);
        return new DeleteBasketResult(true);
    }
}