using System.Data;
using System.Data.SQLite;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Dapper;

namespace Infra.Data.Connection;

[ExcludeFromCodeCoverage]
public static class DatabaseConnection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connection = new SQLiteConnection("Data Source=:memory:");

        return services
            .AddSingleton<IDbConnection>(proveider => connection) 
            .SeedData(connection);
    }

    public static IServiceCollection SeedData(this IServiceCollection services, IDbConnection connection)
    {
        connection.Open();

        var script = File.ReadAllText("script.sql");

        var commands = script.Split(";")
            .Where(command => !string.IsNullOrEmpty(command));

        foreach (var command in commands)
            connection.Execute(command);

        return services;
    }
}
