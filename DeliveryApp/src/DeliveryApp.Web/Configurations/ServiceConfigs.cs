using DeliveryApp.Core.Interfaces;
using DeliveryApp.Infrastructure;
using DeliveryApp.Infrastructure.Email;
using DeliveryApp.Infrastructure.Notifications;
using DeliveryApp.Infrastructure.Payments;

namespace DeliveryApp.Web.Configurations;

public static class ServiceConfigs
{
  public static IServiceCollection AddServiceConfigs(this IServiceCollection services, Microsoft.Extensions.Logging.ILogger logger, WebApplicationBuilder builder)
  {
    services.AddInfrastructureServices(builder.Configuration, logger)
            .AddMediatrConfigs();


    if (builder.Environment.IsDevelopment())
    {
      // Use a local test email server
      // See: https://ardalis.com/configuring-a-local-test-email-server/
      services.AddScoped<IEmailSender, MimeKitEmailSender>();
      services.AddScoped<INotificationService, NotificationService>();
      services.AddScoped<IPaymentService, PaymentService>();

      // Otherwise use this:
      //builder.Services.AddScoped<IEmailSender, FakeEmailSender>();

    }
    else
    {
      services.AddScoped<IEmailSender, MimeKitEmailSender>();
      services.AddScoped<INotificationService, NotificationService>();
      services.AddScoped<IPaymentService, PaymentService>();

    }

    logger.LogInformation("{Project} services registered", "Mediatr and Email Sender");

    return services;
  }


}
