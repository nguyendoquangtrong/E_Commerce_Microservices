using Catalog.API.Exceptions;
using Marten;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetproductByIdResult>;

public record GetproductByIdResult(Product Product);

internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) 
    : IQueryHandler<GetProductByIdQuery,GetproductByIdResult>
{
    public async Task<GetproductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdQueryHandler.Handle called with{@Query}",  query);
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        if (product is null)
            throw new ProductNotFoundException();
        return new GetproductByIdResult(product);
    }
}