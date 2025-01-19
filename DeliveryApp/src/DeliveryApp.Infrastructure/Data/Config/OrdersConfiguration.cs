using DeliveryApp.Core.OrdersAggregate;

namespace DeliveryApp.Infrastructure.Data.Config;

public class OrdersConfiguration : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    // Configure Primary Key
    builder.HasKey(o => o.Id);

    // Configure Properties
    builder.Property(o => o.CustomerId)
      .IsRequired();

    builder.Property(o => o.TotalAmount)
      .HasColumnType("decimal(18,2)")
      .IsRequired();

    builder.Property(o => o.Status)
      .HasConversion(
        s => s.Value,
        s => OrderStatus.FromValue(s)
      )
      .IsRequired();

    builder.Property(o => o.OrderDate)
      .HasColumnType("datetime2")
      .IsRequired();

    builder.Property(o => o.Notes)
      .IsRequired(false)
      .HasMaxLength(500);

    // Configure Value Object: OrderItem
    builder.OwnsMany(o => o.Items, item =>
    {
      item.ToTable("OrderItem");

      item.HasKey(oi => new { oi.ProductName, oi.Price, oi.Quantity });

      item.Property(oi => oi.ProductName)
        .HasMaxLength(DataSchemaConstants.DefaultNameLength)
        .IsRequired();

      item.Property(oi => oi.Price)
        .HasColumnType("decimal(18,4)")
        .IsRequired();

      item.Property(oi => oi.Quantity)
        .IsRequired();
    });

    // Configure Value Object: Shipping Address
    builder.OwnsOne(o => o.ShippingAddress, address =>
    {
      address.Property(a => a.Street)
        .HasMaxLength(DataSchemaConstants.DefaultNameLength)
        .IsRequired();

      address.Property(a => a.City)
        .HasMaxLength(DataSchemaConstants.DefaultNameLength)
        .IsRequired();

      address.Property(a => a.State)
        .HasMaxLength(DataSchemaConstants.DefaultNameLength)
        .IsRequired();

      address.Property(a => a.PostalCode)
        .HasMaxLength(DataSchemaConstants.DefaultNameLength)
        .IsRequired();

      address.Property(a => a.Country)
        .HasMaxLength(DataSchemaConstants.DefaultNameLength)
        .IsRequired();

      address.HasIndex(a => a.PostalCode);
    });

    // Configure Indexes for optimized querying
    builder.HasIndex(o => o.CustomerId);
    builder.HasIndex(o => o.Status);
    builder.HasIndex(o => o.OrderDate);
  }
}
