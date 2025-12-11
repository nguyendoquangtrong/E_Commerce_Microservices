namespace Catalog.API.Products.GetProductByCategory;

public record GetProductsByCategoryQuery(string Category, int? Page, int? PageSize) : IRequest<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductsByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsByCategoryQuery,GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {   
        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToPagedListAsync(query.Page ?? 1, query.PageSize ?? 10, cancellationToken);
        return new GetProductByCategoryResult(products);
    }
}