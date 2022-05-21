namespace FunBooksAndVideos.Models;

/// <summary>
/// Represents the types of memberships which can be sold.
/// </summary>
public class Membership : OnlineProduct
{
    /// <summary>
    /// The name of the type of membership; eg. Book Club, Video Club or Premium.
    /// </summary>
    public string Name { get; set; }
    
    // extension points would be
    // * expiry dates of specific memberships
}