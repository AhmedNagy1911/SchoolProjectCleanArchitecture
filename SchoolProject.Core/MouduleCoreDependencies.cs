using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SchoolProject.Core;

public static class MouduleCoreDependencies
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        //Configration of MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        //Configration of AutoMapper
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
         
        return services;
    }
}
