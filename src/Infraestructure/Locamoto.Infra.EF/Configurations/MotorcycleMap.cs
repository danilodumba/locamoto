using Locamoto.Domain.Entities;
using Locamoto.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locamoto.Infra.EF.Configurations;

public class MotorcycleMap : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.ToTable(LocamotoEFContextSchema.Motorcycle.TableName);

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever().IsRequired();
        builder.Property(p => p.Year).IsRequired();
        builder.Property(p => p.Model).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Plate).HasMaxLength(10).IsRequired();
        builder.Property(p => p.Available);
    }
}

