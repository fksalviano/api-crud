using System.Net;
using API.Filters;

namespace API.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapGroup(this IEndpointRouteBuilder app, string tag, string prefix,
        Action<RouteGroupBuilder> mapEndpointsAction)
    {
        var group = app.MapGroup(prefix).WithTags(tag)
            .WithOpenApi()
            .AddEndpointFilter<ResponseFilter>();

        mapEndpointsAction(group);
        
        return app;
    }

    public static RouteHandlerBuilder ProducesResponse<T>(this RouteHandlerBuilder route, HttpStatusCode httpStatusCode) =>
        route.Produces<ResponseBase<T>>((int)httpStatusCode);

    public static RouteHandlerBuilder ProducesResponse(this RouteHandlerBuilder route, HttpStatusCode httpStatusCode) =>
        route.Produces<ResponseBase<object?>>((int)httpStatusCode);
}
    