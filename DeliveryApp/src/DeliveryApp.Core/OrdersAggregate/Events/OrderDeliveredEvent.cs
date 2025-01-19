namespace DeliveryApp.Core.OrdersAggregate.Events;

internal class OrderDeliveredEvent(Guid orderId) : DomainEventBase
{
  public Guid OrderId { get; } = orderId;
}
