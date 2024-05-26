var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddUseCases();
builder.Services.AddEndpoints();

var app = builder.Build();

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{    
    app.MapScalarApiReference(o =>
    {
        o.EndpointPathPrefix = "api"; 
        o.Title = "API-Clean-VS";
    });
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();