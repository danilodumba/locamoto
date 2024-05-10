using Locamoto.Domain.Entities;
using Locamoto.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locamoto.Infra.EF.Configurations;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(LocamotoEFContextSchema.Order.TableName);

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever().IsRequired();
        builder.Property(p => p.CreatedAt).IsRequired();
        builder.Property(p => p.Status);
        builder.Property(p => p.Cost).IsRequired();

        builder.HasOne(p => p.Deliveryman)
            .WithMany()
            .HasForeignKey(LocamotoEFContextSchema.Order.DeliverymanID);
    }
}

