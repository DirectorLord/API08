using E_Commerce.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistence.Context.Configurations;

internal class OrderConfiguration
    : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasMany( x => x.Items).WithOne().HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(o => o.DeliveryMethod).WithMany().HasForeignKey(o => o.DeliveryMethodId).OnDelete(DeleteBehavior.SetNull);
        builder.OwnsOne(o => o.Address, x => x.WithOwner());
        builder.HasIndex(o => o.UserEmail);
        builder.Property(o => o.Subtotal).HasColumnType("decimal(10,2)");
        builder.Property(o => o.UserEmail).HasColumnType("VarChar").HasMaxLength(20);
        builder.Property(o => o.Status).HasConversion<string>();
        builder.Property(o => o.PayingIntentId).HasColumnType("VarChar").HasMaxLength(128);
    }
}
