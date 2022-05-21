using AutoFixture.Xunit2;
using FluentAssertions;
using FunBooksAndVideos.Abstractions;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Services;
using Moq;

namespace FunBooksAndVideos.Tests;

public class PurchaseOrderServiceTests
{
    [Theory]
    [InlineAutoMoqData]
    public async Task ProcessShouldThrowIfNullPoSupplied(
        PurchaseOrderService sut
    )
    {
        // Arrange

        // Act
        Func<Task> result = () => sut.Process(null);

        // Assert
        await result.Should().ThrowExactlyAsync<ArgumentNullException>();
    }

    [Theory]
    [InlineAutoMoqData]
    public async Task ThrowsExceptionIfPurchaseOrderWithoutItemsIsSupplied(
        PurchaseOrder purchaseOrder,
        PurchaseOrderService sut)
    {
        // Arrange
        purchaseOrder.Items = null!;

        // Act
        Func<Task> result = () => sut.Process(purchaseOrder);

        // Assert
        await result.Should().ThrowExactlyAsync<ArgumentException>();
    }

    [Theory]
    [InlineAutoMoqData]
    public async Task ThrowsExceptionIfPurchaseOrderWithEmptyItemsSupplied(
        PurchaseOrder purchaseOrder,
        PurchaseOrderService sut)
    {
        // Arrange
        purchaseOrder.Items = new List<OrderItem>();

        // Act
        Func<Task> result = () => sut.Process(purchaseOrder);

        // Assert
        await result.Should().ThrowExactlyAsync<ArgumentException>();
    }

    [Theory]
    [InlineAutoMoqData]
    public async Task CallsSuppliedBusinessRules(
        [Frozen] Mock<IBusinessRule> businessRule,
        PurchaseOrder purchaseOrder,
        PurchaseOrderService sut)
    {
        // Arrange

        // Act
        await sut.Process(purchaseOrder);

        // Assert
        businessRule.Verify(x => x.Execute(It.Is<PurchaseOrder>(po => po == purchaseOrder)), Times.Exactly(3)); // 3 is the default AutoFixture value items in a collection
    }
}