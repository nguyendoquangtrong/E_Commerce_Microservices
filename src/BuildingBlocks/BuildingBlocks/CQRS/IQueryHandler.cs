using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQueryHandler<in TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
}