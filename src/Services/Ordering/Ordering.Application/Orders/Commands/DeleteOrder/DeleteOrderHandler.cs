namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderHandler(IApplicationDbontext dbcontext) : ICommandHandler<DeleteOrderCommand,DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.orderId); 
        var order = await dbcontext.Orders.FindAsync([orderId], cancellationToken : cancellationToken);
        if (order == null)
            throw new OrderNotFoundException(command.orderId);
        // Delete Order Entity from command object
        dbcontext.Orders.Remove(order);
        // Save to db
        await dbcontext.SaveChangesAsync(cancellationToken);
        // Return
        return new DeleteOrderResult(true);
    }
}