using Jourlay.Application.Interfaces.Services;
using Jourlay.Application.Utilities.Result;
using Jourlay.Domain.Common.Mediatr;

namespace Jourlay.Application.Features.ContactUs.Queries;

public class ContactUsGetQueryHandler : IRequestHandler<ContactUsGetQuery, Result<List<ContactUsGetResponse>>>
{
    private readonly IContactUsService _contactUsService;

    public ContactUsGetQueryHandler(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    public async Task<Result<List<ContactUsGetResponse>>> Handle(ContactUsGetQuery request, CancellationToken cancellationToken)
    {
        return await _contactUsService.GetAllAsync();
    }
}
