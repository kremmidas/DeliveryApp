namespace DeliveryApp.Core.OrdersAggregate.Specifications;

public sealed class OrderByDateRangeSpec : Specification<Order>
{
  public OrderByDateRangeSpec(DateTime startDate, DateTime endDate) =>
    Query
      .Where(order => order.OrderDate >= startDate && order.OrderDate <= endDate);
}
