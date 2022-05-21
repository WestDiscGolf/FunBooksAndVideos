using FunBooksAndVideos.Abstractions;

namespace FunBooksAndVideos.Models;

/// <summary>
/// Basic customer object. This would be linked to an authenticated user in a "fuller" system.
/// Marked as an IEntity as it can be a root data item by itself if the system was extended to manage the customers or have a customer portal.
/// </summary>
public class Customer : IEntity
{
    /// <summary>
    /// The customer id. This could be linked to the identity provider id, or a system generated value depending on implementation.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// First name of the customer.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name of the customer.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// The type of membership this customer has.
    /// </summary>
    public CurrentMembership Membership { get; set; }

    /// <summary>
    /// The current shipping address for the customer.
    /// </summary>
    public Address ShippingAddress { get; set; }

    /// <summary>
    /// The current billing address for the customer.
    /// </summary>
    public Address BillingAddress { get; set; }

    // other properties which are managed through this system

    // extension points would be
    // * membership history changed over time
    public void SetMembership(string membershipName)
    {
        Membership = new CurrentMembership()
        {
            Name = membershipName
        };
    }
}