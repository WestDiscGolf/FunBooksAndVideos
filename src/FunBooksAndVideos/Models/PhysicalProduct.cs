namespace FunBooksAndVideos.Models;

/// <summary>
/// Physical product eg. Book.
/// </summary>
public class PhysicalProduct : Product
{
    /// <summary>
    /// How heavy is the physical item for shipping calculations.
    /// </summary>
    public decimal WeightInKgs { get; set; }

    public override ProductType Type => ProductType.Physical;

    // extension points would be
    // * additional properties which align with physical items eg. Dimensions or specific handling information.
}