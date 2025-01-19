namespace DeliveryApp.Core.OrdersAggregate.Specifications;

public sealed class OrdersByStatusSpec : Specification<Order>
{
  public OrdersByStatusSpec(OrderStatus status) =>
    Query
        .Where(order => order.Status == status);
}

//a specification to find ready for delivery orders
