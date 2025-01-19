namespace DeliveryApp.Core.Interfaces;

public interface INotificationService
{
  Task SendNotificationAsync(Guid orderId, string title, string message);
}
