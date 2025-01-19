using DeliveryApp.Core.Interfaces;
using DeliveryApp.Core.OrdersAggregate.Events;

namespace DeliveryApp.Core.OrdersAggregate.Handlers;

internal class OrderDeliveredHandler(ILogger<OrderDeliveredHandler> logger, INotificationService notificationService)
  : INotificationHandler<OrderDeliveredEvent>
{
  public async Task Handle(OrderDeliveredEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Order Delivered event for OrderId: {orderId}", domainEvent.OrderId);

    // Notify the customer that the order has been delivered
    await notificationService.SendNotificationAsync(
      domainEvent.OrderId,
      "Order Delivered",
      "Your order has been successfully delivered. Thank you for choosing our service!");
  }
}
