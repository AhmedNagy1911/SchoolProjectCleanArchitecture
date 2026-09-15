using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SchoolProject.Core;

public static class MouduleCoreDependencies
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
