using Jourlay.Domain.Common.Mediatr;

namespace Jourlay.Application.Features.ContactUs.Events;

public sealed class ContactUsAddedEventHandler : INotificationHandler<ContactUsAddedEvent>
{
    public async Task Handle(ContactUsAddedEvent notification, CancellationToken cancellationToken)
    {
        // Log the event
        // Send email notification
        // Update cache
        // etc.

        await Task.CompletedTask;
    }
}
