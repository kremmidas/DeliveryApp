using DeliveryApp.Core.OrdersAggregate.Events;
using DeliveryApp.Core.Interfaces;

namespace DeliveryApp.Core.OrdersAggregate.Handlers;

internal class OrderPlacedHandler(ILogger<OrderPlacedHandler> logger, IPaymentService paymentService)
  : INotificationHandler<OrderPlacedEvent>
{

  public async Task Handle(OrderPlacedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Order Placed event for OrderId: {orderId}", domainEvent.OrderId);

    // Trigger payment processing
    await paymentService.InitiatePaymentAsync(domainEvent.OrderId, domainEvent.TotalAmount);
  }
}
