using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest,TResponse> 
    (ILogger<LoggingBehavior<TRequest,TResponse>> logger)
    : IPipelineBehavior<TRequest,TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] handle request={Request} - Response={Response} - RequestData={RequestData}",
            typeof(TRequest).Name,typeof(TResponse).Name,request);
        var timer = new Stopwatch();
        timer.Start();
        var response = await next();
        timer.Stop();
        var TimeTaken = timer.Elapsed;
        if(TimeTaken.Seconds > 3)
            logger.LogWarning("[PERFORMANCE] The request {Request} tokk {TimeTaken} seconds",
                typeof(TRequest).Name,TimeTaken.Seconds);
        logger.LogInformation("[END] handled {Request} with {Response}",
            typeof(TRequest).Name, typeof(TResponse).Name);
        return response;
    }
}