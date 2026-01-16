using Ordering.Application.Data;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        // Add services to the container
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        
        services.AddDbContext<ApplicationDbContext>((sp,options) =>
        {
            
            var interceptors = sp.GetServices<ISaveChangesInterceptor>();
            options.AddInterceptors(interceptors);
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbontext, ApplicationDbContext>();
        
        return services;
    }
}