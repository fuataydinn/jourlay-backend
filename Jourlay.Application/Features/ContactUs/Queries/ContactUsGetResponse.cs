namespace Jourlay.Application.Features.ContactUs.Queries;

public record ContactUsGetResponse(
    Guid Id,
    string FacebookLink,
    string InstagramLink,
    string YouTubeLink,
    string TwitterLink
);
