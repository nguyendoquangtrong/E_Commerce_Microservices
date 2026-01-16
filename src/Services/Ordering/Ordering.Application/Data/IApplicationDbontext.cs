namespace Ordering.Application.Data;

public interface IApplicationDbontext
{
    DbSet<Customer> Customers { get; }
    DbSet<Product> Products { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}