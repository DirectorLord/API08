using E_Commerce.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistence.Context.Configurations;

public class DeliveryMethodConfiguration
    : IEntityTypeConfiguration<DeliveryMethod>
{
    

    public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
    {
        builder.Property(o => o.Price).HasColumnType("decimal(10,2)");
        builder.Property(o => o.ShortName).HasColumnType("VarChar").HasMaxLength(20);
        builder.Property(o => o.DeliveryTime).HasColumnType("VarCHar");
        builder.Property(o => o.Description).HasColumnType("VarChar").HasMaxLength(20);
    }
}
