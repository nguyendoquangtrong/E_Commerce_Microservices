namespace Ordering.Application.Orders.Queries.GetOrderByName;

public class GetOrderByNameHandler(IApplicationDbontext dbcontext) : IQueryHandler<GetOrderByNameQuery,GetOrderByNameResult>
{
    public async Task<GetOrderByNameResult> Handle(GetOrderByNameQuery query, CancellationToken cancellationToken)
    {
        // Get orders by name using dbcontext
        var orders = await dbcontext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.OrderName.Value.Contains(query.Name))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);
        return new GetOrderByNameResult(orders.ToOrderDtoList());
    }
}