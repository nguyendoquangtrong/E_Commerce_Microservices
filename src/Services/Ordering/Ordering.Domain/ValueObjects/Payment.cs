namespace Ordering.Domain.ValueObjects;

public record Payment
{
    private const int DefaultLength = 3;
    public string? CardName { get; } = default!;
    public string CarNumber { get; } = default!;
    public string Expiration { get; } = default!;
    public string Cvv { get; } = default!;
    public int PaymentMethod { get; } = default!;
    
    protected Payment(){}

    private Payment(string cardName, string carNumber,
        string expiration, string cvv, int paymentMethod)
    {
        CardName = cardName;
        CarNumber = carNumber;
        Expiration = expiration;
        Cvv = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardName, string cardNumber, 
        string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(expiration);
        ArgumentOutOfRangeException.ThrowIfNotEqual(cvv.Length, DefaultLength);
        return new Payment(cardName, cardNumber, expiration , cvv, paymentMethod);
    }
    
}