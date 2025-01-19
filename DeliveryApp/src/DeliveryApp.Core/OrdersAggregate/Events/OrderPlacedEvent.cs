namespace DeliveryApp.Core.OrdersAggregate.Events;

internal class OrderPlacedEvent(
  Guid customerId,
  Guid orderId,
  decimal totalAmount,
  IReadOnlyCollection<OrderItem> items,
  Address shippingAddress,
  string? notes = null)
  : DomainEventBase
{
  public Guid OrderId { get; } = orderId;
  public Guid CustomerId { get; } = customerId;
  public decimal TotalAmount { get; } = totalAmount;
  public IReadOnlyCollection<OrderItem> Items { get; } = items;
  public Address ShippingAddress { get; } = shippingAddress;
  public string? Notes { get; } = notes;
}
