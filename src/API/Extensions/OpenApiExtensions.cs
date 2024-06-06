namespace API.Extensions;

public static class OpenApiExtensions
{
    public static IServiceCollection AddOpenApi(this IServiceCollection services, string version, string tile, string description) =>
        services
            .AddOpenApi(version, options => options.UseTransformer((document, context, cancellationToken) =>
            {
                document.Info = new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = tile,
                    Description = description,
                    Version = version
                };
                return Task.CompletedTask;
            }));
}
