using DeliveryApp.Core.Interfaces;
using DeliveryApp.Core.OrdersAggregate.Events;

namespace DeliveryApp.Core.OrdersAggregate.Handlers;

internal class OrderCancelledHandler(ILogger<OrderCancelledHandler> logger, IEmailSender emailSender)
  : INotificationHandler<OrderCancelledEvent>
{
  public async Task Handle(OrderCancelledEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Order Cancelled event for OrderId: {orderId}", domainEvent.OrderId);

    // Send email notification to the customer
    await emailSender.SendEmailAsync(
      "customer@test.com", // Replace with dynamic logic for recipient
      "from@test.com",
      "Order Cancelled",
      $"Your order with id {domainEvent.OrderId} was cancelled. Reason: {domainEvent.Reason}.");
  }
}
