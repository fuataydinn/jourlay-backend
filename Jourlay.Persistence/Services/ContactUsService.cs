using Jourlay.Application.Features.ContactUs.Commands.Add;
using Jourlay.Application.Features.ContactUs.Queries;
using Jourlay.Application.Interfaces.Repositories;
using Jourlay.Application.Interfaces.Services;
using Jourlay.Application.Utilities.Errors.Base;
using Jourlay.Application.Utilities.Result;
using Jourlay.Domain.Entities;

namespace Jourlay.Persistence.Services;

public class ContactUsService(IContactUsRepository contactUsRepository) : IContactUsService
{
    private readonly IContactUsRepository _contactUsRepository = contactUsRepository;

    public async ValueTask<Result<ContactUsAddResponse>> AddAsync(ContactUsAddCommand command)
    {
        var contactUsEntity = new ContactUsEntity
        {
            FacebookLink = command.FacebookLink ?? string.Empty,
            InstagramLink = command.InstagramLink ?? string.Empty,
            YouTubeLink = command.YouTubeLink ?? string.Empty,
            TwitterLink = command.TwitterLink ?? string.Empty,
        };

        var addedEntity = await _contactUsRepository.AddAsync(contactUsEntity);

        if (addedEntity is null)
            return Error.CreateError("ContactUs entity could not be added.");

        return new ContactUsAddResponse(addedEntity.Id);
    }

    public async ValueTask<Result<List<ContactUsGetResponse>>> GetAllAsync()
    {
        var entities = await _contactUsRepository.GetAllAsync();

        var response = entities.Select(entity => new ContactUsGetResponse(
            entity.Id,
            entity.FacebookLink,
            entity.InstagramLink,
            entity.YouTubeLink,
            entity.TwitterLink
        )).ToList();

        return response;
    }
}