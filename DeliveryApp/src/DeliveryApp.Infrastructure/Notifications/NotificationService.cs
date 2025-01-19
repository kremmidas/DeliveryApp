using DeliveryApp.Core.Interfaces;

namespace DeliveryApp.Infrastructure.Notifications;

public class NotificationService : INotificationService
{
  public Task SendNotificationAsync(Guid orderId, string title, string message)
  {
    //mimic a real notification service
    Console.WriteLine($"Sending notification to order {orderId} with title {title} and message {message}");
    return Task.CompletedTask;
  }
}
