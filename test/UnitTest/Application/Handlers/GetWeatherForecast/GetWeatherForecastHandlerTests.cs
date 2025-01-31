using Application.Handlers.WeatherForecast.GetWeatherHandler;
using Infrastructure.Repositories;
using Domain.Models;
using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UnitTest.Application.Handlers.GetWeatherForecast;

public class GetWeatherForecastUseCaseTests
{
    private readonly GetWeatherHandler _sut;
    private readonly Mock<IWeatherForecastRepository> _repository;

    private readonly AutoMocker _mocker = new();
    private readonly Fixture _fixture = new();

    public GetWeatherForecastUseCaseTests()
    {
        _repository = _mocker.GetMock<IWeatherForecastRepository>();
        _sut = _mocker.CreateInstance<GetWeatherHandler>();
    }

    [Fact]
    public async Task ShouldExecuteSuccessfully()
    {
        //Arrange
        var command =  _fixture.Create<GetWeatherQuery>();
        var expected = _fixture.CreateMany<WeatherForecastModel>(5);

        _repository.Setup(repo => repo.Get()).ReturnsAsync(expected);

        //Act
        var result = await _sut.Handle(command, default);

        //Assert
        result.Should().BeOfType<Ok<IEnumerable<WeatherForecastModel>>>();
    }

    private bool IsEquivalent(IEnumerable<WeatherForecastModel> source, IEnumerable<WeatherForecastModel> expected)
    {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

    [Fact]
    public async Task ShouldExecuteNotFound()
    {
        //Arrange
        var command =  _fixture.Create<GetWeatherQuery>();
        var expected = _fixture.CreateMany<WeatherForecastModel>(0);
        _repository.Setup(repo => repo.Get()).ReturnsAsync(expected);

        //Act
        var result = await _sut.Handle(command, default);

        //Assert
        result.Should().BeOfType<Ok<IEnumerable<WeatherForecastModel>>>();
    }

    [Fact]
    public async Task ShouldExecuteWithError()
    {
        //Arrange
        var command =  _fixture.Create<GetWeatherQuery>();
        var expected = (IEnumerable<WeatherForecastModel>) null!;
        _repository.Setup(repo => repo.Get()).ReturnsAsync(expected);

        //Act
        var result = await _sut.Handle(command, default);

        //Assert
        result.Should().BeOfType<ProblemHttpResult>();
    }
}
