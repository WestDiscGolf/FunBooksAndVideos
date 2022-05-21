using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Services;

public interface IPurchaseOrderService
{
    Task Process(PurchaseOrder purchaseOrder);
}