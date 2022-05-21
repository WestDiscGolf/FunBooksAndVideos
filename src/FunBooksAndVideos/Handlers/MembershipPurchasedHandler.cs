using FunBooksAndVideos.Abstractions;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Services;
using MediatR;

namespace FunBooksAndVideos.Handlers;

/// <summary>
/// Example of a notification handler which was raised from the purchase order service.
/// This handler is responsible for updating the customer with the new membership information.
/// </summary>
internal class MembershipPurchasedHandler : INotificationHandler<MembershipPurchasedEvent>
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<Membership> _membershipRepository;

    public MembershipPurchasedHandler(
        IRepository<Customer> customerRepository, 
        IRepository<Membership> membershipRepository)
    {
        _customerRepository = customerRepository;
        _membershipRepository = membershipRepository;
    }

    public async Task Handle(MembershipPurchasedEvent request, CancellationToken cancellationToken)
    {
        Customer customer = await _customerRepository.GetById(request.CustomerId);
        Membership membership = await _membershipRepository.GetById(request.MembershipId);

        customer.SetMembership(membership.Name);

        await _customerRepository.Save(customer);
    }
}