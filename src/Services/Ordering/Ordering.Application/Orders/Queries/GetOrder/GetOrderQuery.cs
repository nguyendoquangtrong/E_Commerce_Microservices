namespace Ordering.Application.Orders.Queries.GetOrder;

public record GetOrderQuery(PaginationRequest PaginationRequest) : IQuery<GetOrderResult>;
public record GetOrderResult(PaginateResult<OrderDto> orders);