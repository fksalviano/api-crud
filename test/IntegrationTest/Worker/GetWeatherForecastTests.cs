using System.Net.Http.Json;
using FluentAssertions;
using Worker.Controllers.GetWeatherForecast;

namespace IntegrationTest.Worker;

public class GetWeatherForecastTests : IClassFixture<ApplicationFactory>
{
    private readonly ApplicationFactory _factory;

    public GetWeatherForecastTests(ApplicationFactory factory) =>
        _factory = factory;

    [Fact]
    public async Task ShouldGetWeatherForecastsSuccessfully()
    {
        //Arrange
        var client = _factory.GetClient();        

        //Act
        var response = await client.GetAsync(Routes.WeatherForecast);
        var content = await response.Content.ReadFromJsonAsync<GetWeatherForecastResponse>();

        //Assert
        response.EnsureSuccessStatusCode();        
        content.Should().NotBeNull();
        content!.Result!.WeatherForecasts.Should().NotBeNullOrEmpty();
    }
}