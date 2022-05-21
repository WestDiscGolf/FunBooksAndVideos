using MediatR;

namespace FunBooksAndVideos.Services;

public class GenerateShippingSlipCommand : IRequest<Unit>
{
    public Guid PurchaseOrderId { get; set; }
}