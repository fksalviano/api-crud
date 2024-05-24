var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.SwaggerDoc("v1", new()
{
    Title = "API-Clean-VS",
    Description = ".Net Core API using Clean Architecture and Vertical Slice"
}));

builder.Services.AddUseCases();
builder.Services.AddEndpoints();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseScalar(o => o.RoutePrefix = "");
}

app.MapEndpoints();

app.UseHttpsRedirection();

app.Run();