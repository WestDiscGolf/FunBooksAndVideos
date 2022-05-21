namespace FunBooksAndVideos.Models;

/// <summary>
/// Address record for the customer billing and shipping details.
/// </summary>
public class Address
{
    public string Line1 { get; set; }

    public string Line2 { get; set; }
    
    public string Line3 { get; set; }
    
    public string Line4 { get; set; }

    public string Line5 { get; set; }

    // extension points would be
    // * Additional properties for more address related items.
}