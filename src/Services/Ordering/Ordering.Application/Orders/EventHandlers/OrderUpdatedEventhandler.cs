namespace Ordering.Application.Orders.EventHandlers;

public class OrderUpdatedEventhandler(ILogger<OrderUpdatedEventhandler> logger) : INotificationHandler<OrderUpdatedEvent>
{
    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}