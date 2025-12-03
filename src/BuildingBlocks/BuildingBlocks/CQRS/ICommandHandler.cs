using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommandHandler<in TCommand> 
    : ICommandHandler<TCommand, Unit>
    where TCommand : IRequest<Unit>
{
}

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse> 
    where TCommand : IRequest<TResponse>
    where TResponse : notnull
{
}