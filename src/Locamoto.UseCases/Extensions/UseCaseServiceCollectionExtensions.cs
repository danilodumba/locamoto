using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Locamoto.UseCases.Extensions;
public static class UseCaseServiceCollectionExtensions
{
    public static void AddUseCases(this IServiceCollection services)
    {
        var application = AppDomain.CurrentDomain.Load("Locamoto.UseCases");

        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(application);
        });
    }
}
