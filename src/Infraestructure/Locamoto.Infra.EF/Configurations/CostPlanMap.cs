using Locamoto.Domain.Entities;
using Locamoto.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locamoto.Infra.EF.Configurations;

public class CostPlanMap : IEntityTypeConfiguration<CostPlan>
{
    public void Configure(EntityTypeBuilder<CostPlan> builder)
    {
        builder.ToTable(LocamotoEFContextSchema.CostPlan.TableName);

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever().IsRequired();
        builder.Property(p => p.StartDay).IsRequired();
        builder.Property(p => p.EndDay).IsRequired();
        builder.Property(p => p.CostPerDay).IsRequired();
        builder.Property(p => p.AdditionalCostPerDay).IsRequired();
        builder.Property(p => p.PercentageFine).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(50).IsRequired();

        builder.HasData(InitPlan());
    }

    private IList<CostPlan> InitPlan()
    {
        return new List<CostPlan>
        {
            new CostPlan(7, 7, 30, 20, 50, "Seven Days Plan"),
            new CostPlan(15, 15, 28, 40, 50, "Fifteen Days Plan"),
            new CostPlan(30, 30, 22, 60, 50, "Thirty Days Plan"),
        };
    }
}

