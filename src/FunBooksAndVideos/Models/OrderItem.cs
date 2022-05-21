namespace FunBooksAndVideos.Models;

/// <summary>
/// Order item which contains the individual item row for the purchase order.
/// </summary>
public class OrderItem
{
    /// <summary>
    /// The associated Product. This will keep the data in place in a denormalised form for use in no sql dbs eg. CosmosDB.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// The number of items requested in the purchase order.
    /// </summary>
    public int NoOfItems { get; set; }

    /// <summary>
    /// Total cost of this item row based on the no. of items specified.
    /// </summary>
    public decimal TotalCost { get; set; }

    // extension points would be
    // * ability to change the individual item from the stock product value
    // * apply discount on specific items
}