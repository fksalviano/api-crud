var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi("v1",
    "Api-CRUD",
    ".Net 9 API crud with MediatR, Commands, Handlers and valiadtions with PipelineBehavior.");

builder.Services.AddMediator();

var app = builder.Build();

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(o => o.EndpointPathPrefix = "api");
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();