using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Abstractions;
using SchoolProject.Infrasturcture.Context;

namespace SchoolProject.Infrasturcture;

public static class MouduleInfrasturctureDependencies
{
    public static IServiceCollection AddInfrasturctureDependencies(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection") ??
                 throw new InvalidOperationException("Connection string 'DefaultConnection' is not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
