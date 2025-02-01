using Application.Behaviors;
using Application.Mappers;
using Domain.Extensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;


namespace Application.Installers;

[ExcludeFromCodeCoverage]
public static class ApplicationInstaller
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(configuration => configuration
                .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                .AddOpenBehavior(typeof(RequestValidationBehavior<,>)));

        services
            .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            .AddDomainValidation();

        services
            .AddAutoMapper(typeof(EntityToModelProfile));

        return services;
    }

    private static IServiceCollection AddDomainValidation(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        ValidationsExtension.SetProvider(serviceProvider);
        
        return services;
    }

}
