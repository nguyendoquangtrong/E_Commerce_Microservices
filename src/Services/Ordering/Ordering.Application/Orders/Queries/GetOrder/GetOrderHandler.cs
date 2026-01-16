namespace Ordering.Application.Orders.Queries.GetOrder;

public class GetOrderHandler(IApplicationDbontext dbcontext) : IQueryHandler<GetOrderQuery,GetOrderResult>
{
    public async Task<GetOrderResult> Handle(GetOrderQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;
        var totalCount = await dbcontext.Orders.LongCountAsync(cancellationToken);
        // Get orders with pagination
        var orders = await dbcontext.Orders
            .Include(o => o.OrderItems)
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        // Return
        return new GetOrderResult(
            new PaginateResult<OrderDto>
                (pageIndex,
                pageSize, 
                totalCount, 
                orders.ToOrderDtoList()));
    }
}