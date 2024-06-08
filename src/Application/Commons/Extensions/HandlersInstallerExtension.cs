using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Application.Commons.Repositories.Installers;

namespace Application.Commons.Extensions;

[ExcludeFromCodeCoverage]
public static class HandlersInstallerExtension
{
    public static IServiceCollection AddHandlersDependencies(this IServiceCollection services) =>
        services
            .AddRepositories();
}