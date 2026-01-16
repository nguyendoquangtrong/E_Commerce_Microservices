namespace Ordering.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderHandler(IApplicationDbontext dbcontext ) : ICommandHandler<UpdateOrderCommand,UpdateOrderResult>
{
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.Order.Id); 
        var order = await dbcontext.Orders.FindAsync([orderId], cancellationToken : cancellationToken);
        if (order == null)
            throw new OrderNotFoundException(command.Order.Id);
        // Update Order Entity from command object
        UpdateOrderWithNewValue(order, command.Order);
        // Save to db
        dbcontext.Orders.Update(order);
        await dbcontext.SaveChangesAsync(cancellationToken);
        // Return
        return new UpdateOrderResult(true);
    }

    private void UpdateOrderWithNewValue(Order order, OrderDto orderDto)
    {
        var updateShippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName,
            orderDto.ShippingAddress.EmailAddress, orderDto.ShippingAddress.AddressLine,
            orderDto.ShippingAddress.Country, orderDto.ShippingAddress.State, orderDto.ShippingAddress.ZipCode);
        var updateBillingAddress = Address.Of(orderDto.BillingAddress.FirstName, orderDto.BillingAddress.LastName,
            orderDto.BillingAddress.EmailAddress, orderDto.BillingAddress.AddressLine,
            orderDto.BillingAddress.Country, orderDto.BillingAddress.State, orderDto.BillingAddress.ZipCode);
        var updatePayment = Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration,
            orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod);
        order.Update(
            orderName: OrderName.Of(orderDto.OrderName),
            shippingAddress: updateShippingAddress,
            billingAddress: updateBillingAddress,
            payment: updatePayment,
            status: orderDto.Status);
    }
}