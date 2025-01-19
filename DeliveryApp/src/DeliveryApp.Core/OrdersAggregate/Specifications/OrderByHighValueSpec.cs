namespace DeliveryApp.Core.OrdersAggregate.Specifications;

public sealed class OrderByHighValueSpec : Specification<Order>
{
  public OrderByHighValueSpec(decimal value) =>
    Query
      .Where(order => order.TotalAmount >= value);
}
