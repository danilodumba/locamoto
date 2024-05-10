
using Locamoto.Domain.Entities;
using Locamoto.Infra.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Locamoto.Infra.EF.Contexts;

public class LocamotoEFContext: DbContext
{
    public DbSet<Rent> Rentals => Set<Rent>();
    public DbSet<CostPlan> CostPlans => Set<CostPlan>();
    public DbSet<Deliveryman> Deliverymans => Set<Deliveryman>();
    public DbSet<Motorcycle> Motorcycles => Set<Motorcycle>();
    public DbSet<Order> Orders => Set<Order>();

    public LocamotoEFContext(DbContextOptions<LocamotoEFContext> dbContextOptions)
            : base(dbContextOptions)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(LocamotoEFContextSchema.DefualtSchema);

        modelBuilder.ApplyConfiguration(new DeliverymanMap());
        modelBuilder.ApplyConfiguration(new CostPlanMap());
        modelBuilder.ApplyConfiguration(new MotorcycleMap());
        modelBuilder.ApplyConfiguration(new OrderMap());
        modelBuilder.ApplyConfiguration(new RentMap());
    }
}
