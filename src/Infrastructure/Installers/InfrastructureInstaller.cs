using DapperExtensions;
using DapperExtensions.Sql;
using Infrastructure.Database;
using Infrastructure.Database.Mappers;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Installers;

public static class InfrastructureInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase();

        AddDapperExtensions();

        services
            .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

        return services;
    }

    public static void AddDapperExtensions()
    {
        DapperAsyncExtensions.SqlDialect = new SqliteDialect();
        DapperAsyncExtensions.DefaultMapper = typeof(DefaultTableMapper<>);
        DapperAsyncExtensions.SetMappingAssemblies([ Assembly.GetExecutingAssembly() ]);
    }
}
