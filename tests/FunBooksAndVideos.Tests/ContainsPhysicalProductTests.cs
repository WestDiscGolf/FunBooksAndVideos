using AutoFixture.Xunit2;
using FluentAssertions;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Services;
using MediatR;
using Moq;

namespace FunBooksAndVideos.Tests;

public class ContainsPhysicalProductTests
{
    [Theory]
    [InlineAutoMoqData]
    public async Task ThrowsExceptionIfNullPurchaseOrderIsSupplied(
        ContainsPhysicalProduct sut)
    {
        // Arrange

        // Act
        Func<Task> result = () => sut.Execute(null!);

        // Assert
        await result.Should().ThrowExactlyAsync<ArgumentNullException>();
    }

    [Theory]
    [InlineAutoMoqData]
    public async Task ThrowsExceptionIfPurchaseOrderWithoutItemsIsSupplied(
        PurchaseOrder purchaseOrder,
        ContainsPhysicalProduct sut)
    {
        // Arrange
        purchaseOrder.Items = null!;

        // Act
        Func<Task> result = () => sut.Execute(purchaseOrder);

        // Assert
        await result.Should().ThrowExactlyAsync<ArgumentException>();
    }

    [Theory]
    [InlineAutoMoqData]
    public async Task ThrowsExceptionIfPurchaseOrderWithEmptyItemsSupplied(
        PurchaseOrder purchaseOrder,
        ContainsPhysicalProduct sut)
    {
        // Arrange
        purchaseOrder.Items = new List<OrderItem>();

        // Act
        Func<Task> result = () => sut.Execute(purchaseOrder);

        // Assert
        await result.Should().ThrowExactlyAsync<ArgumentException>();
    }

    [Theory]
    [InlineAutoMoqData]
    public async Task ProcessShouldRaiseShippingSlipIfAnyPhysical(
        [Frozen] Mock<IMediator> mediator,
        PurchaseOrder purchaseOrder,
        PhysicalProduct product,
        OrderItem orderItem,
        ContainsPhysicalProduct sut
    )
    {
        // Arrange
        orderItem.Product = product;
        purchaseOrder.Items = new List<OrderItem>
        {
            orderItem
        };

        // Act
        await sut.Execute(purchaseOrder);

        // Assert
        mediator.Verify(x => x.Send(It.Is<GenerateShippingSlipCommand>(e => e.PurchaseOrderId == purchaseOrder.Id), It.IsAny<CancellationToken>()), Times.Once);
    }
}