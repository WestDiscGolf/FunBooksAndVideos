using FunBooksAndVideos.Abstractions;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Services;
using MediatR;

namespace FunBooksAndVideos.Handlers;

/// <summary>
/// Example of a command request handler which was raised from the purchase order service.
/// This handler is responsible for generating the shipping label.
/// </summary>
internal class GenerateShippingSlipHandler : IRequestHandler<GenerateShippingSlipCommand, Unit>
{
    private readonly IRepository<PurchaseOrder> _purchaseOrderRepository;

    public GenerateShippingSlipHandler(
        IRepository<PurchaseOrder> purchaseOrderRepository)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<Unit> Handle(GenerateShippingSlipCommand request, CancellationToken cancellationToken)
    {
        PurchaseOrder purchaseOrder = await _purchaseOrderRepository.GetById(request.PurchaseOrderId);

        // todo: call the shipping label generator functionality with the customer address and purchase order information

        return Unit.Value;
    }
}