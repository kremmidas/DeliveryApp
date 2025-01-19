using DeliveryApp.Core.Interfaces;
using DeliveryApp.Core.OrdersAggregate.Events;

namespace DeliveryApp.Core.OrdersAggregate.Handlers;

internal class OrderConfirmedHandler(ILogger<OrderConfirmedHandler> logger, INotificationService notificationService)
  : INotificationHandler<OrderConfirmedEvent>
{
  public async Task Handle(OrderConfirmedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Order Confirmed event for OrderId: {orderId}", domainEvent.OrderId);

    // Notify the customer of confirmation
    await notificationService.SendNotificationAsync(
      domainEvent.OrderId,
      "Order Confirmed",
      "Your order has been confirmed and will be processed shortly.");
  }
}
