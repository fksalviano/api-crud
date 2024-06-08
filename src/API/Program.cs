var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi("v1",
    "API-Clean-VS",
    ".Net Core API sample using Clean Architecture and Vertical Slice");

builder.Services.AddMediatR(configuration => configuration
    .RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
    .AddOpenBehaviors());

builder.Services.AddHandlersDependencies();

var app = builder.Build();

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(o => o.EndpointPathPrefix = "api");
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();