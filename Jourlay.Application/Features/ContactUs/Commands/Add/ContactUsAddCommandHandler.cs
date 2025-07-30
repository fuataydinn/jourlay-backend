using Jourlay.Application.Interfaces.Services;
using Jourlay.Application.Utilities.Result;
using Jourlay.Domain.Common.Mediatr;

namespace Jourlay.Application.Features.ContactUs.Commands.Add;

public class ContactUsAddCommandHandler : IRequestHandler<ContactUsAddCommand, Result<ContactUsAddResponse>>
{
    private readonly IContactUsService _contactUsService;

    public ContactUsAddCommandHandler(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    public async Task<Result<ContactUsAddResponse>> Handle(ContactUsAddCommand request, CancellationToken cancellationToken)
    {
        return await _contactUsService.AddAsync(request);
    }
}