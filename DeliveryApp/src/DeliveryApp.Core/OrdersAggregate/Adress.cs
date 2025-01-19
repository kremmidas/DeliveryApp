namespace DeliveryApp.Core.OrdersAggregate;

public class Address : ValueObject
{
  public string Street { get; private set; }
  public string City { get; private set; }
  public string State { get; private set; }
  public string PostalCode { get; private set; }
  public string Country { get; private set; }
  
  public Address(string street, string city, string state, string postalCode, string country)
  {
    Street = Guard.Against.NullOrEmpty(street, nameof(street));
    City = Guard.Against.NullOrEmpty(city, nameof(city));
    State = Guard.Against.NullOrEmpty(state, nameof(state));
    PostalCode = Guard.Against.NullOrEmpty(postalCode, nameof(postalCode));
    Country = Guard.Against.NullOrEmpty(country, nameof(country));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Street;
    yield return City;
    yield return State;
    yield return PostalCode;
    yield return Country;
  }
}
