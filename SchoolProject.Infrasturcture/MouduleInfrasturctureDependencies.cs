using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Infrasturcture.Bases;
using SchoolProject.Infrasturcture.Repositories;

namespace SchoolProject.Infrasturcture;

public static class MouduleInfrasturctureDependencies
{
    public static IServiceCollection AddInfrasturctureDependencies(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

        return services;
    }
}
