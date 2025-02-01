using Application.Handlers.WeatherForecast;
using Application.Handlers.WeatherForecast.Requests;
using Infrastructure.Repositories;
using Domain.Entities;
using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UnitTest.Application.Handlers.GetWeatherForecast;

public class GetWeatherForecastHandlerTests
{
    private readonly GetWeatherHandler _sut;
    private readonly Mock<IWeatherForecastRepository> _repository;

    private readonly AutoMocker _mocker = new();
    private readonly Fixture _fixture = new();

    public GetWeatherForecastHandlerTests()
    {
        _repository = _mocker.GetMock<IWeatherForecastRepository>();
        _sut = _mocker.CreateInstance<GetWeatherHandler>();
    }

    [Fact]
    public async Task ShouldExecuteSuccessfully()
    {
        //Arrange
        var command =  _fixture.Create<GetWeatherRequest>();
        var expected = _fixture.CreateMany<WeatherForecastEntity>(5);

        _repository.Setup(repo => repo.Get()).ReturnsAsync(expected);

        //Act
        var result = await _sut.Handle(command, default);

        //Assert
        result.Should().BeOfType<Ok<IEnumerable<WeatherForecastEntity>>>();
    }

    private bool IsEquivalent(IEnumerable<WeatherForecastEntity> source, IEnumerable<WeatherForecastEntity> expected)
    {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

    [Fact]
    public async Task ShouldExecuteNotFound()
    {
        //Arrange
        var command =  _fixture.Create<GetWeatherRequest>();
        var expected = _fixture.CreateMany<WeatherForecastEntity>(0);
        _repository.Setup(repo => repo.Get()).ReturnsAsync(expected);

        //Act
        var result = await _sut.Handle(command, default);

        //Assert
        result.Should().BeOfType<Ok<IEnumerable<WeatherForecastEntity>>>();
    }

    [Fact]
    public async Task ShouldExecuteWithError()
    {
        //Arrange
        var command =  _fixture.Create<GetWeatherRequest>();
        var expected = (IEnumerable<WeatherForecastEntity>) null!;
        _repository.Setup(repo => repo.Get()).ReturnsAsync(expected);

        //Act
        var result = await _sut.Handle(command, default);

        //Assert
        result.Should().BeOfType<ProblemHttpResult>();
    }
}
