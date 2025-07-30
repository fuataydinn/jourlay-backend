using Jourlay.Application.Utilities.Result;
using Jourlay.Domain.Common.Mediatr;

namespace Jourlay.Application.Features.ContactUs.Queries;

public class ContactUsGetQuery : IRequest<Result<List<ContactUsGetResponse>>>;
