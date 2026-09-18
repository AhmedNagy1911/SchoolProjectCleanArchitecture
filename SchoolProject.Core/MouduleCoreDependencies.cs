using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
using System.Reflection;

namespace SchoolProject.Core;

public static class MouduleCoreDependencies
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        //Configration of MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));   // ده اللي بيشغّل الـ validators
        });

        //Configration of AutoMapper
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
