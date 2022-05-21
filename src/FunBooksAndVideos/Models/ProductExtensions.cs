namespace FunBooksAndVideos.Models;

/// <summary>
/// Product based extension methods to remove the common checks to allow for the code to be more readable.
/// </summary>
public static class ProductExtensions
{
    /// <summary>
    /// Is membership check. If the product is a type of Membership it will return true, otherwise false.
    /// </summary>
    /// <param name="product">The Product which is being checked to see what the type is.</param>
    /// <returns><c>true</c> if it is a Membership, otherwise <c>false</c>.</returns>
    public static bool IsMembership(this Product product) => product.GetType() == typeof(Membership);

    /// <summary>
    /// Is physical check. If the product is a physical product it will return true, otherwise false.
    /// </summary>
    /// <param name="product">The Product which to check whether physical or not.</param>
    /// <returns><c>true</c> if the product is physical, otherwise <c>false</c>.</returns>
    public static bool IsPhysical(this Product product) => product.Type == ProductType.Physical;

    /// <summary>
    /// Is online check. If the product is online only it will return true, otherwise false.
    /// </summary>
    /// <param name="product">The Product which to check whether online or not.</param>
    /// <returns><c>true</c> if the product is online, otherwise <c>false</c>.</returns>
    public static bool IsOnline(this Product product) => product.Type == ProductType.Online;
}