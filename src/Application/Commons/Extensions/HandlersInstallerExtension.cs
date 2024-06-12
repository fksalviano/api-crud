using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Application.Commons.Repositories.Installers;
using MediatR;
using FluentValidation;

namespace Application.Commons.Extensions;

[ExcludeFromCodeCoverage]
public static class HandlersInstallerExtension
{
    public static IServiceCollection AddHandlersDependencies(this IServiceCollection services) =>
        services
            .AddRepositories()
            .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

    public static MediatRServiceConfiguration AddOpenBehaviors(this MediatRServiceConfiguration configuration)
    {        
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces()
            .Any(intf => intf.IsGenericType && intf.GetGenericTypeDefinition() == typeof(IPipelineBehavior<,>)));

        foreach (var behaviorType  in types)
            configuration.AddOpenBehavior(behaviorType);

        return configuration;
    }

}
