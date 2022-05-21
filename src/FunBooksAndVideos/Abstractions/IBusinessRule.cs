using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Abstractions;

public interface IBusinessRule
{
    Task Execute(PurchaseOrder purchaseOrder);
}