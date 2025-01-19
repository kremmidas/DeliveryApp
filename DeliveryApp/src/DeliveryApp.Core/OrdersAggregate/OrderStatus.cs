namespace DeliveryApp.Core.OrdersAggregate;

using Ardalis.SmartEnum;

public class OrderStatus : SmartEnum<OrderStatus>
{
  public static readonly OrderStatus Placed = new OrderStatus(nameof(Placed), 1);
  public static readonly OrderStatus Confirmed = new OrderStatus(nameof(Confirmed), 2);
  public static readonly OrderStatus Assigned = new OrderStatus(nameof(Assigned), 3);
  public static readonly OrderStatus Delivered = new OrderStatus(nameof(Delivered), 4);
  public static readonly OrderStatus Cancelled = new OrderStatus(nameof(Cancelled), 5);
  private OrderStatus(string name, int value) : base(name, value) { }

  public bool CanTransitionTo(OrderStatus targetStatus)
  {
    return this switch
    {
      _ when this == Placed && targetStatus == Confirmed => true,
      _ when this == Confirmed && (targetStatus == Assigned || targetStatus == Cancelled) => true,
      _ when this == Assigned && targetStatus == Delivered => true,
      _ when this == Placed && targetStatus == Cancelled => true,
      _ => false
    };
  }
}
