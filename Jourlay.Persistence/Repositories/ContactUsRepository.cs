using Jourlay.Application.Interfaces.Repositories;
using Jourlay.Domain.Entities;
using Jourlay.Persistence.Contexts;

namespace Jourlay.Persistence.Repositories;

public class ContactUsRepository : EfRepositoryBase<ContactUsEntity>, IContactUsRepository
{
    public ContactUsRepository(ApplicationDbContext context): base(context)
    {
    }
}