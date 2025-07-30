using Jourlay.Application.Utilities.Result;
using Jourlay.Domain.Common.Mediatr;

namespace Jourlay.Application.Features.ContactUs.Commands.Add;

public record ContactUsAddCommand(
    string FacebookLink,
    string InstagramLink,
    string YouTubeLink,
    string TwitterLink
    ) : IRequest<Result<ContactUsAddResponse>>;

