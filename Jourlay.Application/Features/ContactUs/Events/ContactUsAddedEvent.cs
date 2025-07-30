using Jourlay.Domain.Common.Mediatr;

namespace Jourlay.Application.Features.ContactUs.Events;

public record ContactUsAddedEvent(
    Guid Id,
    string FacebookLink,
    string InstagramLink,
    string YouTubeLink,
    string TwitterLink,
    DateTime CreatedAt
) : INotification;
