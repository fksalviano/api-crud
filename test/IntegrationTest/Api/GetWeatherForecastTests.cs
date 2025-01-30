using System.Net.Http.Json;
using FluentAssertions;

namespace IntegrationTest.Api;

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

        //Assert
        response.EnsureSuccessStatusCode();
    }
}