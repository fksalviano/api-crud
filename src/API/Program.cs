var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi("v1",
    "Api-CRUD",
    ".Net 9 API crud with MediatR, Commands, Handlers and valiadtions with PipelineBehavior.");

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