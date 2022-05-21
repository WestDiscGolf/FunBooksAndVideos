namespace FunBooksAndVideos.Models;

public class CurrentMembership
{
    public string Name { get; set; }

    // extension points would be
    // * history of when it started
    // * any customer specific changes to the membership might be allowed eg. custom discount etc.
}