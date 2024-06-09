namespace API.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapGroup(this IEndpointRouteBuilder app, string tag, string prefix,
        Action<RouteGroupBuilder> mapEndpointsAction)
    {
        var group = app.MapGroup(prefix).WithTags(tag).WithOpenApi();

        mapEndpointsAction(group);
        
        return app;
    }
}
    