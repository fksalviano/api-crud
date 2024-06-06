using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using API.Endpoints.WeatherForecast;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Application.Handlers.GetWeatherForecast;
using Application.Commons.Domain.Result;
using API.Extensions;
using Application.Handlers.GetWeatherForecast.Domain;

namespace UnitTest.Worker.Controllers.GetWeatherForecast;

public class GetWeatherForecastEndpointTests
{
    private readonly WeatherForecastEndpoints _sut;    
    private readonly Mock<GetWeatherForecastHandler> _handler;

    private readonly AutoMocker _mocker = new();
    private readonly Fixture _fixture = new();

    public GetWeatherForecastEndpointTests()
    {
        _handler = _mocker.GetMock<GetWeatherForecastHandler>();
        _sut = _mocker.CreateInstance<WeatherForecastEndpoints>();        
    }

    [Fact]
    public async Task ShouldGetWeatherForecastSuccessfully()
    {
        //Arrange
        var result = _fixture.CreateMany<WeatherForecast>();
        var resultOk = Result.Ok(result);

        var expected = resultOk.ToResponse();

        _handler.Setup(handler => handler.Handle(It.IsAny<GetWeatherForecastCommand>(), default))
            .ReturnsAsync(resultOk);

        //Act
        var response = await _sut.GetWeatherForecast() as ObjectResult;

        //Assert
        response!.StatusCode.Should().Be(Status200OK);
        response!.Value.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task ShouldGetWeatherForecastNotFound()
    {
        // Arrange
        var result = Result.NotFound();
        var expexted = result.ToResponse();
        
        _handler.Setup(handler => handler.Handle(It.IsAny<GetWeatherForecastCommand>(), default))
            .ReturnsAsync(result);

        //Act
        var resoponse = await _sut.GetWeatherForecast() as ObjectResult;

        //Assert
        resoponse!.StatusCode.Should().Be(Status404NotFound);
    }

    [Fact]
    public async Task ShouldGetWeatherForecastError()
    {
        //Arrange
        var message = _fixture.Create<string>();
        var result = Result.Error(message);

        var expected = result.ToResponse();

        _handler.Setup(handler => handler.Handle(It.IsAny<GetWeatherForecastCommand>(), default))
            .ReturnsAsync(result);

        //Act
        var resposne = await _sut.GetWeatherForecast() as ObjectResult;

        //Assert
        resposne!.StatusCode.Should().Be(Status500InternalServerError);
        resposne!.Value.Should().BeEquivalentTo(expected);
    }
}