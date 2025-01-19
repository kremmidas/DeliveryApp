namespace DeliveryApp.Core.OrdersAggregate.Specifications;

public sealed class OrdersReadyForDeliverySpec : Specification<Order>
{
  public OrdersReadyForDeliverySpec() =>
    Query
      .Where(order => order.Status == OrderStatus.Confirmed);
}
