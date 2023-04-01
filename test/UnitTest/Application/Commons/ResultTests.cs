using Application.Commons.Domain;
using AutoFixture;
using FluentAssertions;

namespace UnitTest.Application.Commons;

public class ResultTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void ShouldCrateSuccessfully()
    {
        //Act
        var result = new Result(true, string.Empty);

        //Assert 
        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
        result.ErrorMessage.Should().BeEmpty();
    }

    [Fact]
    public void ShouldCrateError()
    {
        //Arrange
        var message = _fixture.Create<string>();

        //Act
        var result = Result.Error(message);

        //Assert 
        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.ErrorMessage.Should().Be(message);
    }
}
