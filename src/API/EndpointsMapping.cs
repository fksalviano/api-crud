
public static class EndpointsMapping
{
    public static IEndpointRouteBuilder MapEndpoints (this IEndpointRouteBuilder app) =>
        app
            .MapWeatherForcastEndpoints();
}
