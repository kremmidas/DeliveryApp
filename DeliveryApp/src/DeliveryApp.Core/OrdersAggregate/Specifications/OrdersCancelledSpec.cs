namespace DeliveryApp.Core.OrdersAggregate.Specifications;

public sealed class OrdersCancelledSpec : Specification<Order>
{
  public OrdersCancelledSpec() =>
    Query
      .Where(order => order.Status == OrderStatus.Cancelled);
}
