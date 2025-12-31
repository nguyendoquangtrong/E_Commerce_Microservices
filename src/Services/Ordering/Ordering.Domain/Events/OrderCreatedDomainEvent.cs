namespace Ordering.Domain.Events;

public record OrderCreatedDomainEvent(Order Order) : IDomainEvent;