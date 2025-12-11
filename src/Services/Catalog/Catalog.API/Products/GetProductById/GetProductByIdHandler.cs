using Catalog.API.Exceptions;
using Marten;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetproductByIdResult>;

public record GetproductByIdResult(Product Product);

internal class GetProductByIdQueryHandler(IDocumentSession session) 
    : IQueryHandler<GetProductByIdQuery,GetproductByIdResult>
{
    public async Task<GetproductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        if (product is null)
            throw new ProductNotFoundException(query.Id);
        return new GetproductByIdResult(product);
    }
}