namespace DeliveryApp.Core.OrdersAggregate.Events;

internal class OrderCancelledEvent(Guid orderId, string reason) : DomainEventBase
{
  public Guid OrderId { get; } = orderId;
  public string Reason { get; } = reason;
}
