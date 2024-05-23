using System.Diagnostics.CodeAnalysis;
using Application.Commons.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Commons.Extensions;

[ExcludeFromCodeCoverage]
public static class InstallerExtensions
{
    public static IServiceCollection InstallServices(this IServiceCollection services)
    {
        var installersTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly
            .GetTypes().Where(type => typeof(IServiceInstaller).IsAssignableFrom(type) && type.IsClass));

        foreach (var type in installersTypes)
        {
            var installer = (IServiceInstaller)Activator.CreateInstance(type)!;
                        
            installer.InstallServices(services);
        }
        return services;
    }
}