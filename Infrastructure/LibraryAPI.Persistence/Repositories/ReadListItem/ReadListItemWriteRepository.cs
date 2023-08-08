using LibraryAPI.Application.Repositories.ReadListItem;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Persistence.Repositories.ReadListItem;

public class ReadListItemWriteRepository : WriteRepository<Domain.Entities.ReadListItem>, IReadListItemWriteRepository
{
    public ReadListItemWriteRepository(LibraryAPIDbContext context) : base(context)
    {
    }
}