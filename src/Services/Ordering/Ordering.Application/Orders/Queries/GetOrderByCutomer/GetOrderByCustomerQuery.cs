namespace Ordering.Application.Orders.Queries.GetOrderByCutomer;

public record GetOrderByCutomerQuery(Guid CustomerId) : IQuery<GetOrderByCutomerResult>;
public record GetOrderByCutomerResult(IEnumerable<OrderDto> orders);
