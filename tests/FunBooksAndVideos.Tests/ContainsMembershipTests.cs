using AutoFixture.Xunit2;
using FluentAssertions;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Services;
using MediatR;
using Moq;

namespace FunBooksAndVideos.Tests;

public class ContainsMembershipTests
{
    [Theory]
    [InlineAutoMoqData]
    public async Task ThrowsExceptionIfNullPurchaseOrderIsSupplied(
        ContainsMembership sut)
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
        ContainsMembership sut)
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
        ContainsMembership sut)
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
    public async Task ShouldRaiseEventWhenMembershipContainedInPurchaseOrder(
        [Frozen] Mock<IMediator> mediator,
        PurchaseOrder purchaseOrder,
        Membership membership,
        OrderItem orderItem,
        ContainsMembership sut
    )
    {
        // Arrange
        orderItem.Product = membership;
        purchaseOrder.Items = new List<OrderItem> { orderItem };

        // Act
        await sut.Execute(purchaseOrder);

        // Assert
        mediator.Verify(x => x.Publish(It.Is<MembershipPurchasedEvent>(e => e.CustomerId == purchaseOrder.Customer.Id && e.MembershipId == membership.Id), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [InlineAutoMoqData]
    public async Task ShouldNotRaiseEventWhenNoMembershipPresentInPurchaseOrder(
        [Frozen] Mock<IMediator> mediator,
        PurchaseOrder data,
        ContainsMembership sut
    )
    {
        // Arrange

        // Act
        await sut.Execute(data);

        // Assert
        mediator.Verify(x => x.Publish(It.IsAny<MembershipPurchasedEvent>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}