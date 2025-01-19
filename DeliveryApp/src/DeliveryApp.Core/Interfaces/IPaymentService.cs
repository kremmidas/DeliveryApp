namespace DeliveryApp.Core.Interfaces;

public  interface IPaymentService
{
  Task InitiatePaymentAsync(Guid orderId, decimal totalAmount);
}
