using FluentAssertions;
using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Tests;

public class ProductExtensionsTests
{
    [Theory]
    [InlineAutoMoqData]
    public void IsMembership(
        Membership sut
    )
    {
        // Arrange

        // Act
        var result = sut.IsMembership();

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineAutoMoqData]
    public void IsOnline_Membership(
        Membership sut
    )
    {
        // Arrange

        // Act
        var result = sut.IsOnline();

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineAutoMoqData]
    public void IsOnline_Video(
        Video sut
    )
    {
        // Arrange

        // Act
        var result = sut.IsOnline();

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineAutoMoqData]
    public void IsOnline_Physical(
        PhysicalProduct sut
    )
    {
        // Arrange

        // Act
        var result = sut.IsOnline();

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineAutoMoqData]
    public void IsPhysical(
        PhysicalProduct sut
    )
    {
        // Arrange

        // Act
        var result = sut.IsPhysical();

        // Assert
        result.Should().BeTrue();
    }
}