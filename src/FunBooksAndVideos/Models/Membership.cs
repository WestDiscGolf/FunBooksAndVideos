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

public class Video : OnlineProduct
{
    /// <summary>
    /// Name of the video.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The classification rating of the film eg U, PG, 12, 15, 18
    /// </summary>
    public string Classification { get; set; }
}

public class OnlineProduct : Product
{
    /// <inheritdoc />
    public override ProductType Type => ProductType.Online;
}