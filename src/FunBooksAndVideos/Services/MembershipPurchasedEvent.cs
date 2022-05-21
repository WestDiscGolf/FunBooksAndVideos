using MediatR;

namespace FunBooksAndVideos.Services;

public class MembershipPurchasedEvent : INotification
{
    public Guid CustomerId { get; set; }

    public Guid MembershipId { get; set; }
}