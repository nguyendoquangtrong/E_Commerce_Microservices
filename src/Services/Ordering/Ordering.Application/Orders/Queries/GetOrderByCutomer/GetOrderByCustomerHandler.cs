namespace Ordering.Application.Orders.Queries.GetOrderByCutomer;

public class GetOrderByCustomerHandler(IApplicationDbontext dbcontext) : IQueryHandler<GetOrderByCutomerQuery,GetOrderByCutomerResult>
{
    public async Task<GetOrderByCutomerResult> Handle(GetOrderByCutomerQuery query, CancellationToken cancellationToken)
    {
        // Get orders bt Customer using dbcontext
        var orders = await dbcontext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);
        // Return
        return new GetOrderByCutomerResult(orders.ToOrderDtoList());
    }
}