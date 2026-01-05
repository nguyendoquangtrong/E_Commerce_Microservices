using Microsoft.AspNetCore.Builder;
using Ordering.Infrastructure.Data.Extentions;

namespace Ordering.Infrastructure.Extensions;

public static class DatabaseExtension
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.MigrateAsync().GetAwaiter().GetResult();
        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedCustumorAsync(context);
        await SeedProductAsync(context);
        await SeedOrderWithItemAsync(context);
    }

    private static async Task SeedCustumorAsync(ApplicationDbContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            await context.Customers.AddRangeAsync(InitalData.Customers);
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedProductAsync(ApplicationDbContext context)
    {
        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(InitalData.Products);
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedOrderWithItemAsync(ApplicationDbContext context)
    {
        if (!await context.Orders.AnyAsync())
        {
            await context.Orders.AddRangeAsync(InitalData.Orders);
            await context.SaveChangesAsync();
        }
    }
}