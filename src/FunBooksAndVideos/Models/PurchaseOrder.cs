using FunBooksAndVideos.Abstractions;

namespace FunBooksAndVideos.Models;

/// <summary>
/// Purchase order record.
/// </summary>
public class PurchaseOrder : IEntity
{
    /// <summary>
    /// System generated unique id of the specified order.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The human readable order id. This would be system generated or user specified.
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// The customer it the order is owned by. This is denormalized to allow for ease of storage in no sql db.
    /// It also gives a snap shot of the customer at time of ordering to see name, shipping address etc.
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    /// The calculated total of the purchase order.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// The list of order items which make up the full order.
    /// </summary>
    public List<OrderItem> Items { get; set; } = new();
}