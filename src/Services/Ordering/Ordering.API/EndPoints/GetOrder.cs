namespace Ordering.API.EndPoints;

public record GetOrderResponse(PaginateResult<OrderDto> Orders);

public class GetOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async ([AsParameters] PaginationRequest request,ISender sender) =>
        {
            var result = await sender.Send(new GetOrderQuery(request));
            var response = new GetOrderResponse(result.orders);
            return Results.Ok(response);
        })
        .WithName("GetOrder")
        .Produces<GetOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Order")
        .WithDescription("Get Order");
    }
}