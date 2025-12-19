using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.DeleteBasket;

// public record DeleteBasketRequest(string UserName);

public record DeleteBasketResponse(bool IsSuccess);
public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{UserName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(userName);
            var response = result.Adapt<DeleteBasketResponse>();
            return Results.Ok(response);
        }).WithName("DeleteBasket")
        .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Basket")
        .WithDescription("Delete Basket"); 
    }
}