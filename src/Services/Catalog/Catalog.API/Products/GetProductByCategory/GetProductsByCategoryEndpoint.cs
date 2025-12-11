namespace Catalog.API.Products.GetProductByCategory;

public record GetProductsByCategoryRequest(string Category,int? Page, int? PageSize);

public record GetProductsByCategoryResponse(IEnumerable<Product> Products);

public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}",
                async ([AsParameters] GetProductsByCategoryRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetProductsByCategoryQuery>();
            var result = await sender.Send(query);
            var response = result.Adapt<GetProductsByCategoryResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProductByCategory")
        .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get product by category")
        .WithDescription("Get product by category");   
    }
}