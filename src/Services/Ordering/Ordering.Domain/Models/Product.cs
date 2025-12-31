namespace Ordering.Domain.Models;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public static Product Create(ProductId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        var product = new Product
        {
            Id = id,
            Name = name,
            Email = email
        };
        return product;
    }
}