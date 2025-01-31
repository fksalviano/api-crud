using System.Reflection;
using Dapper;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Mappers;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Installers;

public static class InfrastructureInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase();

        services
            .AddScoped<WeatherForecastMapper>();

        DapperExtensions.DapperExtensions.DefaultMapper = typeof(CustomPluralizedMapper<>);
        DapperExtensions.DapperExtensions.SetMappingAssemblies([ Assembly.GetExecutingAssembly() ]);        

        services            
            .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();    

        return services;
    }
}
