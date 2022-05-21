using FunBooksAndVideos.Abstractions;
using FunBooksAndVideos.Models;
using MediatR;

namespace FunBooksAndVideos.Services;

public class ContainsPhysicalProduct : IBusinessRule
{
    private readonly IMediator _mediator;

    public ContainsPhysicalProduct(IMediator mediator)
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

        // assumption: all items in same purchase order are being shipped to the same address

        if (purchaseOrder.Items.Any(x => x.Product.IsPhysical()))
        {
            // Send selected for the generate command as only require 1 handler to respond to this command.
            await _mediator.Send(new GenerateShippingSlipCommand
            {
                PurchaseOrderId = purchaseOrder.Id
            });
        }
    }
}