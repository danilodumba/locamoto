using Locamoto.Domain.Entities;
using Locamoto.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locamoto.Infra.EF.Configurations;

public class RentMap : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.ToTable(LocamotoEFContextSchema.Rent.TableName);

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever().IsRequired();
        builder.Property(p => p.StartDate).IsRequired();
        builder.Property(p => p.CreatedDate).IsRequired();
        builder.Property(p => p.ExpectedCost).IsRequired();
        builder.Property(p => p.ExpectedEndDate).IsRequired();
        builder.Property(p => p.EndDate);
        builder.Property(p => p.FineCost).IsRequired();
        builder.Property(p => p.RealCost).IsRequired();
        builder.Property(p => p.Status);


        builder.HasOne(p => p.Deliveryman).WithMany(p => p.Rents).HasForeignKey(LocamotoEFContextSchema.Rent.DeliverymanID);
        builder.HasOne(p => p.Plan).WithMany().HasForeignKey(LocamotoEFContextSchema.Rent.PlanID);
        builder.HasOne(p => p.Motorcycle).WithMany().HasForeignKey(LocamotoEFContextSchema.Rent.MotorcycleID);
    }
}
