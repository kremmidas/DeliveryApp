namespace DeliveryApp.Core.OrdersAggregate.Specifications;

public sealed class OrderByCustomerSpec : Specification<Order>
{
  public OrderByCustomerSpec(Guid customerId) =>
    Query
      .Where(order => order.CustomerId == customerId);
}
