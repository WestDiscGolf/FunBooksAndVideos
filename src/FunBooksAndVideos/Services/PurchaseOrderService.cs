using FunBooksAndVideos.Abstractions;
using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Services;

public class PurchaseOrderService : IPurchaseOrderService
{
    private readonly IBusinessRule[] _rules;

    public PurchaseOrderService(IBusinessRule[] rules)
    {
        _rules = rules;
    }

    public async Task Process(PurchaseOrder purchaseOrder)
    {
        ArgumentNullException.ThrowIfNull(purchaseOrder);
        
        if (purchaseOrder.Items == null || purchaseOrder.Items.Any() == false)
        {
            throw new ArgumentException("No order items supplied.", nameof(purchaseOrder.Items));
        }

        foreach (var businessRule in _rules)
        {
            await businessRule.Execute(purchaseOrder);
        }
    }
}