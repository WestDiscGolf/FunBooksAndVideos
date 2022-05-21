namespace FunBooksAndVideos.Models;

public abstract class OnlineProduct : Product
{
    /// <inheritdoc />
    public override ProductType Type => ProductType.Online;
}