using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Repositories.ReadList;
using LibraryAPI.Application.Repositories.ReadListItem;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Persistence.Repositories.ReadListItem
{
    public class ReadListItemReadRepository : ReadRepository<Domain.Entities.ReadListItem>,IReadListItemReadRepository
    {
        public ReadListItemReadRepository(LibraryAPIDbContext context) : base(context)
        {
        }
    }
}
