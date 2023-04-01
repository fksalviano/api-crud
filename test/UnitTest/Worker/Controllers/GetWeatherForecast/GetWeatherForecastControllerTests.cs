using Application.UseCases.GetWeather.Ports;
using Application.UseCases.GetWeatherForecast.Abstractions;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using Worker.Controllers.GetWeatherForecast;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace UnitTest.Worker.Controllers.GetWeatherForecast;

public class GetWeatherForecastControllerTests
{
    private readonly GetWeatherForecastController _sut;
    private readonly IGetWeatherForecastOutputPort _outputPort;
    private readonly Mock<IGetWeatherForecastUseCase> _useCase;

    private readonly AutoMocker _mocker = new();
    private readonly Fixture _fixture = new();

    public GetWeatherForecastControllerTests()
    {
        _useCase = _mocker.GetMock<IGetWeatherForecastUseCase>();
        _sut = _mocker.CreateInstance<GetWeatherForecastController>();
        _outputPort = (_sut as IGetWeatherForecastOutputPort);
    }

    [Fact]
    public async Task ShouldGetWeatherForecastSuccessfully()
    {
        //Arrange
        var output = _fixture.Create<GetWeatherForecastOutput>();
        var expected = GetWeatherForecastResponse.Success(output);
        _useCase.Setup(useCase => useCase.ExecuteAsync()).Callback(() =>_outputPort.Ok(output));

        //Act
        var result = await _sut.GetWeatherForecast() as ObjectResult;

        //Assert
        result!.StatusCode.Should().Be(Status200OK);
        result!.Value.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task ShouldGetWeatherForecastNotFound()
    {
        //Arrange
        _useCase.Setup(useCase => useCase.ExecuteAsync()).Callback(() =>_outputPort.NotFound());

        //Act
        var result = await _sut.GetWeatherForecast() as ObjectResult;

        //Assert
        result!.StatusCode.Should().Be(Status404NotFound);
    }

    [Fact]
    public async Task ShouldGetWeatherForecastError()
    {
        //Arrange
        var message = _fixture.Create<string>();
        var expected = GetWeatherForecastResponse.Error(message);
        _useCase.Setup(useCase => useCase.ExecuteAsync()).Callback(() =>_outputPort.Error(message));

        //Act
        var result = await _sut.GetWeatherForecast() as ObjectResult;

        //Assert
        result!.StatusCode.Should().Be(Status500InternalServerError);
        result!.Value.Should().BeEquivalentTo(expected);
    }
}