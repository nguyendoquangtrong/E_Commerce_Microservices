namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category) : IRequest<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger) : IQueryHandler<GetProductByCategoryQuery,GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {   
        logger.LogInformation("GetProductsByCategoryQueryHandler.Handle called with{@Query}",  query);
        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync();
        return new GetProductByCategoryResult(products);
    }
}