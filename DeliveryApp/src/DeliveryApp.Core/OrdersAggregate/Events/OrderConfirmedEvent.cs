namespace DeliveryApp.Core.OrdersAggregate.Events;

internal class OrderConfirmedEvent(Guid orderId) : DomainEventBase
{
  public Guid OrderId { get; } = orderId;
}
