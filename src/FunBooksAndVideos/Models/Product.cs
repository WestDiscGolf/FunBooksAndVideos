using FunBooksAndVideos.Abstractions;

namespace FunBooksAndVideos.Models;

/// <summary>
/// The product type which defines individual product types.
/// Marked as an IEntity as it can be a root data item by itself if the system was extended to product management.
/// </summary>
public abstract class Product : IEntity
{
    /// <summary>
    /// The unique product id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The SKU of the specific product this record represents.
    /// </summary>
    public string Sku { get; set; }

    /// <summary>
    /// The human readable name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Brief description of the type of product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The individual item cost for this SKU.
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary>
    /// The type of the product.
    /// </summary>
    public abstract ProductType Type { get; }
}