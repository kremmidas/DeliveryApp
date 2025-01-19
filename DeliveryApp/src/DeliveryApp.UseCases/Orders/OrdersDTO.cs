namespace DeliveryApp.UseCases.Orders;

public record OrdersDto (int Id, string OrderNumber, string CustomerName, string Address, string Phone, string Status, string PaymentType, string PaymentStatus, string DeliveryType, string DeliveryStatus, string Note, string CreatedAt, string UpdatedAt);
