using Jourlay.Application.Features.ContactUs.Commands.Add;
using Jourlay.Application.Features.ContactUs.Queries;
using Jourlay.Application.Utilities.Result;

namespace Jourlay.Application.Interfaces.Services;

public interface IContactUsService
{
    ValueTask<Result<ContactUsAddResponse>> AddAsync(ContactUsAddCommand command);
    ValueTask<Result<List<ContactUsGetResponse>>> GetAllAsync();
}
