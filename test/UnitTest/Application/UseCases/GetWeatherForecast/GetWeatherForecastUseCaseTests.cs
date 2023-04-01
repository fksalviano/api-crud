using Application.UseCases.GetWeather;
using Application.UseCases.GetWeather.Ports;
using Application.UseCases.GetWeatherForecast.Abstractions;
using Application.UseCases.GetWeatherForecast.Domain;
using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace UnitTest.Application.UseCases.GetWeatherForecast;

public class GetWeatherForecastUseCaseTests
{
    private readonly IGetWeatherForecastUseCase _sut;
    private readonly Mock<IWeatherForecastRepository> _repository;
    private readonly Mock<IGetWeatherForecastOutputPort> _outputPort;

    private readonly AutoMocker _mocker = new();
    private readonly Fixture _fixture = new();

    public GetWeatherForecastUseCaseTests()
    {
        _repository = _mocker.GetMock<IWeatherForecastRepository>();
        _outputPort = _mocker.GetMock<IGetWeatherForecastOutputPort>();

        _sut = _mocker.CreateInstance<GetWeatherForecastUseCase>();
        _sut.SetOutputPort(_outputPort.Object);
    }

    [Fact]
    public async Task ShouldExecuteSuccessfully()
    {
        //Arrange
        var expected = _fixture.CreateMany<WeatherForecast>(5);
        _repository.Setup(repo => repo.GetWeatherForecasts()).ReturnsAsync(expected);

        //Act
        await _sut.ExecuteAsync();

        //Assert
        _outputPort.Verify(outputPort =>
            outputPort.Ok(It.Is<GetWeatherForecastOutput>(output => IsEquivalent(output.WeatherForecasts, expected))),
            Times.Once);

        _outputPort.Verify(outputPort => outputPort.NotFound(),
            Times.Never);

        _outputPort.Verify(outputPort => outputPort.Error(It.IsAny<string>()),
            Times.Never);
    }

    private bool IsEquivalent(IEnumerable<WeatherForecast> source, IEnumerable<WeatherForecast> expected)
    {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

    [Fact]
    public async Task ShouldExecuteNotFound()
    {
        //Arrange
        var expected = _fixture.CreateMany<WeatherForecast>(0);
        _repository.Setup(repo => repo.GetWeatherForecasts()).ReturnsAsync(expected);

        //Act
        await _sut.ExecuteAsync();

        //Assert
        _outputPort.Verify(outputPort => outputPort.NotFound(),
            Times.Once);

        _outputPort.Verify(outputPort => outputPort.Ok(It.IsAny<GetWeatherForecastOutput>()),
            Times.Never);

        _outputPort.Verify(outputPort => outputPort.Error(It.IsAny<string>()),
            Times.Never);
    }

    [Fact]
    public async Task ShouldExecuteWithError()
    {
        //Arrange
        var expected = (IEnumerable<WeatherForecast>) null!;
        _repository.Setup(repo => repo.GetWeatherForecasts()).ReturnsAsync(expected);

        //Act
        await _sut.ExecuteAsync();

        //Assert
        _outputPort.Verify(outputPort => outputPort.Error(It.IsAny<string>()),
            Times.Once);

        _outputPort.Verify(outputPort => outputPort.NotFound(),
            Times.Never);

        _outputPort.Verify(outputPort => outputPort.Ok(It.IsAny<GetWeatherForecastOutput>()),
            Times.Never);
    }
}
