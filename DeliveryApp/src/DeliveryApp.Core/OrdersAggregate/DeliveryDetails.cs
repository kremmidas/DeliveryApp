// src/DeliveryApp.Core/OrdersAggregate/DeliveryDetails.cs
namespace DeliveryApp.Core.OrdersAggregate;

public class DeliveryDetails : ValueObject
{
  private Guid DriverId { get; set; }
  private DateTime Eta { get; set; }

  private DeliveryDetails() { } // For EF Core

  public DeliveryDetails(Guid driverId)
  {
    DriverId = Guard.Against.Default(driverId, nameof(driverId));
    Eta = CalculateEta();
  }

  private static DateTime CalculateEta()
  {
    return DateTime.UtcNow.AddHours(1); // Placeholder logic for ETA calculation
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return DriverId;
    yield return Eta;
  }
}
