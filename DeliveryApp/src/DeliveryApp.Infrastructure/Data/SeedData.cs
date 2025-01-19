using DeliveryApp.Core.OrdersAggregate;

namespace DeliveryApp.Infrastructure.Data;

public static class SeedData
{
  private static readonly Order _order1 = new Order(
    customerId: Guid.NewGuid(),
    items: new List<OrderItem>
    {
      new OrderItem("Item A", 10.99m, 2),
      new OrderItem("Item B", 5.49m, 1),
    },
    shippingAddress: new Address("123 Main St", "Anytown", "Michigan", "12345","USA")
    
  );

  private static readonly Order _order2 = new Order(
    customerId: Guid.NewGuid(),
    items: new List<OrderItem>
    {
      new OrderItem("Item C", 20.00m, 3),
      new OrderItem("Item D", 7.50m, 1),
    },
    shippingAddress: new Address("456 Elm St", "Othertown", "Michigan", "54321", "USA"),
    notes: "Please deliver after 5pm"
    
  );

  public static async Task InitializeAsync(AppDbContext dbContext)
  {
    if (await dbContext.Orders.AnyAsync()) return; // DB has been seeded

    await PopulateTestDataAsync(dbContext);
  }

  public static async Task PopulateTestDataAsync(AppDbContext dbContext)
  {
    dbContext.Orders.AddRange(new[] { _order1, _order2 });
    await dbContext.SaveChangesAsync();
  }
}
