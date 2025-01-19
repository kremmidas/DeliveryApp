using DeliveryApp.Core.OrdersAggregate.Events;

namespace DeliveryApp.Core.OrdersAggregate;

public class Order : EntityBase<Guid>, IAggregateRoot
{
  public Guid CustomerId { get; private set; }
  private readonly List<OrderItem> _items = [];
  public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
  public decimal TotalAmount { get; private set; }
  public OrderStatus Status { get; private set; }
  public DateTime OrderDate { get; private set; }
  
  public Address? ShippingAddress { get; private set; }
  
  public string? Notes { get; private set; } 

  // Default for EF Core
  private Order() 
  {
    OrderDate = DateTime.UtcNow;
    Status = OrderStatus.Placed; 
  }

  public Order(Guid customerId, IEnumerable<OrderItem> items, Address shippingAddress, string? notes = null)
  {
    Guard.Against.Default(customerId, nameof(customerId));
    var orderItems = items as OrderItem[] ?? items.ToArray();
    Guard.Against.NullOrEmpty(orderItems, nameof(items));
    Guard.Against.Null(shippingAddress, nameof(shippingAddress));

    Id = Guid.NewGuid();
    CustomerId = customerId;
    _items.AddRange(orderItems);
    TotalAmount = CalculateTotalAmount();
    Status = OrderStatus.Placed; 
    OrderDate = DateTime.UtcNow;
    ShippingAddress = shippingAddress;
    Notes = notes?.Trim();

    RegisterDomainEvent(new OrderPlacedEvent(Id, CustomerId, TotalAmount, Items, ShippingAddress, Notes));
  }

  public void Confirm()
  {
    EnsureStatus(OrderStatus.Placed);
    ChangeStatus(OrderStatus.Confirmed);

    RegisterDomainEvent(new OrderConfirmedEvent(Id));
  }

  public void Cancel(string reason)
  {
    EnsureStatus(OrderStatus.Placed, OrderStatus.Confirmed);

    ChangeStatus(OrderStatus.Cancelled);
    RegisterDomainEvent(new OrderCancelledEvent(Id, reason));
  }

  public void MarkAsDelivered()
  {
    EnsureStatus(OrderStatus.Confirmed);
    ChangeStatus(OrderStatus.Delivered);

    RegisterDomainEvent(new OrderDeliveredEvent(Id));
  }

  private Result EnsureStatus(params OrderStatus[] validStatuses)
  {
    return !validStatuses.Contains(Status) ? Result.Error($"Invalid operation for order with status '{Status.Name}'") : Result.Success();
  }

  private Result ChangeStatus(OrderStatus newStatus)
  {
    if (!Status.CanTransitionTo(newStatus))
    {
      return Result.Error($"Invalid transition from '{Status.Name}' to '{newStatus.Name}'");
    }

    Status = newStatus;
    return Result.Success();
  }

  private decimal CalculateTotalAmount() =>
    _items.Sum(item => item.Price * item.Quantity);
}
