var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InstallServices()
    .AddControllers();

builder.Services.AddSwagger("v1",
    "API-Clean-VS", 
    "Sample API with Clean Architecture and Vertical Slice");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();