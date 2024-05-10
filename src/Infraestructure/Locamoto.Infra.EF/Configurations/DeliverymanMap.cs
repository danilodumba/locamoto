using Locamoto.Domain.Entities;
using Locamoto.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locamoto.Infra.EF.Configurations;

public class DeliverymanMap : IEntityTypeConfiguration<Deliveryman>
{
    public void Configure(EntityTypeBuilder<Deliveryman> builder)
    {
        builder.ToTable(LocamotoEFContextSchema.Deliveryman.TableName);

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever().IsRequired();
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.BirthDate).IsRequired();

        builder.ComplexProperty(p => p.Cnh, p => {
            p.Property(n => n.Number).IsRequired().HasColumnName(LocamotoEFContextSchema.Deliveryman.CnhNumber);
            p.Property(n => n.Type).IsRequired().HasColumnName(LocamotoEFContextSchema.Deliveryman.CnhType);
            p.Property(n => n.Image).HasColumnName(LocamotoEFContextSchema.Deliveryman.CnhImage);
        });

        builder.ComplexProperty(p => p.Cnpj, p => {
            p.Property(n => n.Value).IsRequired().HasColumnName(LocamotoEFContextSchema.Deliveryman.Cnpj);
        });
    }
}
