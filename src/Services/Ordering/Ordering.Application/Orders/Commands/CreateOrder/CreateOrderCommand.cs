namespace Ordering.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(OrderDto Order) 
    : ICommand<CreateOrderResult>;
    
public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Order name is required.");
        RuleFor(x=> x.Order.CustomerId).NotEmpty().WithMessage("Customer id is required.");
        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("Order items are required.");
    }
}