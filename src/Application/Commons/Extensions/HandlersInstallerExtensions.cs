using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Application.Commons.Repositories.Extensions;
using MediatR;
using FluentValidation;

namespace Application.Commons.Extensions;

[ExcludeFromCodeCoverage]
public static class HandlersInstallerExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services) =>
        services
            .AddMediatR(configuration => configuration
                .RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddOpenBehaviors())
            .AddHandlersDependencies();

    public static IServiceCollection AddHandlersDependencies(this IServiceCollection services) =>
        services
            .AddRepositories()
            .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

    public static void AddOpenBehaviors(this MediatRServiceConfiguration configuration)
    {        
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces()
            .Any(intf => intf.IsGenericType && intf.GetGenericTypeDefinition() == typeof(IPipelineBehavior<,>)));

        foreach (var behaviorType  in types)
            configuration.AddOpenBehavior(behaviorType);        
    }

}
