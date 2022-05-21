using FunBooksAndVideos.Abstractions;
using FunBooksAndVideos.Models;
using MediatR;

namespace FunBooksAndVideos.Services;

public class ContainsMembership : IBusinessRule
{
    private readonly IMediator _mediator;

    public ContainsMembership(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Execute(PurchaseOrder purchaseOrder)
    {
        ArgumentNullException.ThrowIfNull(purchaseOrder);
        
        if (purchaseOrder.Items == null || purchaseOrder.Items.Any() == false)
        {
            throw new ArgumentException("No order items supplied.", nameof(purchaseOrder.Items));
        }

        // assumption: Only 1 membership can be ordered by Purchase Order

        var membershipOrderItem = purchaseOrder.Items.FirstOrDefault(x => x.Product.IsMembership());
        if (membershipOrderItem is not null)
        {
            // Publish selected as a membership purchase event could trigger many other processes around membership management
            await _mediator.Publish(new MembershipPurchasedEvent
            {
                CustomerId = purchaseOrder.Customer.Id,
                MembershipId = membershipOrderItem.Product!.Id
            });
        }
    }
}