using E_Commerce.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistence.Context.Configurations;

public class OrderItemConfiguration
    : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.OwnsOne( i => i.Product, o => o.WithOwner());
        builder.Property(o => o.Price).HasColumnType("decimal(10,2)");
    }
}
