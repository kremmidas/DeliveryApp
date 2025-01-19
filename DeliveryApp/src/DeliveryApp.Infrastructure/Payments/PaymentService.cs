using DeliveryApp.Core.Interfaces;

namespace DeliveryApp.Infrastructure.Payments;

public class PaymentService : IPaymentService
{
  public Task InitiatePaymentAsync(Guid orderId, decimal totalAmount)
  {
    //mimic a real payment service
    Console.WriteLine($"Initiating payment for order {orderId} with total amount {totalAmount}");
    return Task.CompletedTask;
  }
}
