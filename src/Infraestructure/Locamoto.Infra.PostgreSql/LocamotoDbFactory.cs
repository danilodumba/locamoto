using Locamoto.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Locamoto.Infra.PostgreSql;

public class LocamotoDbFactory: IDesignTimeDbContextFactory<LocamotoEFContext>
{
    public LocamotoEFContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<LocamotoEFContext>();
        optionBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=locamoto;Password=123456;Database=locamoto;", a => a.MigrationsAssembly("Locamoto.Infra.PostgreSql"));

        return new LocamotoEFContext(optionBuilder.Options);
    }
}
