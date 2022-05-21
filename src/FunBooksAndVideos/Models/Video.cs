namespace FunBooksAndVideos.Models;

/// <summary>
/// Video product which represents the online video which the company sells.
/// </summary>
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

    // extension points would be
    // * formats available; HD 4k etc.
    // * link to video
    // * is able to be downloaded to watch offline
}