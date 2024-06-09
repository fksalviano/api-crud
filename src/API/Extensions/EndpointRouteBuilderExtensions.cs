namespace API.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapGroup(this IEndpointRouteBuilder app, string tag, string prefix,
        Action<RouteGroupBuilder> action)
    {
        var group = app.MapGroup(prefix).WithTags(tag).WithOpenApi();

        action.Invoke(group);

        return app;
    }
}