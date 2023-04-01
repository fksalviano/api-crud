using Application.Commons.Extensions;
using AutoFixture;
using FluentAssertions;
using FluentValidation.Results;

namespace UnitTest.Application.Commons;

public class ResultExtensionsTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void ShouldConvertValidationToResult()
    {
        //Arrange
        var validation = _fixture.Create<ValidationResult>();

        //Act
        var result = validation.ToResult();

        //Assert
        result.Should().NotBeNull();
        result.IsValid.Should().Be(validation.IsValid);
        result.ErrorMessage.Should().Contain(validation.Errors[0].ErrorMessage);
    }
}
