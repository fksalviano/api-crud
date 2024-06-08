using Application.Commons.Repositories;
using FluentAssertions;
using Moq.AutoMock;

namespace UnitTest.Application.UseCases.GetWeatherForecast;

public class WeatherForecastRepositoryTests
{
    private readonly IWeatherForecastRepository _sut;
    private readonly AutoMocker _mocker = new();

    public WeatherForecastRepositoryTests()
    {
        _sut = _mocker.CreateInstance<WeatherForecastRepository>();
    }

    [Fact]
    public async Task ShouldGetWeatherForecastsSuccessfully()
    {
        //Act
        var result = await _sut.GetAll();

        //Assert
        result.Should().NotBeNullOrEmpty();
    }
}