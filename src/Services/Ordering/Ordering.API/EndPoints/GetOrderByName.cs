namespace Ordering.API.EndPoints;

public record GetOrderByNameResponse(IEnumerable<OrderDto> Orders);

public class GetOrderByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
        {
            var result = await sender.Send(new GetOrderByNameQuery(orderName));
            var response = new GetOrderByNameResponse(result.orders);
            return Results.Ok(response); 
        })
        .WithName("GetOrderByName")
        .Produces<GetOrderByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Order By Name")
        .WithDescription("Get Order By Name");
    }
}