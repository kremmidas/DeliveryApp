namespace DeliveryApp.Core.OrdersAggregate;

public class OrderItem : ValueObject
{
  public string ProductName { get; }
  public decimal Price { get; }
  public int Quantity { get; }

  public OrderItem(string productName, decimal price, int quantity)
  {
    ProductName = Guard.Against.NullOrEmpty(productName, nameof(productName));
    Price = Guard.Against.NegativeOrZero(price, nameof(price));
    Quantity = Guard.Against.NegativeOrZero(quantity, nameof(quantity));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return ProductName;
    yield return Price;
    yield return Quantity;
  }
}
