using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Repositories.ReadList;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Persistence.Repositories.ReadList
{
    public class ReadListReadRepository : ReadRepository<Domain.Entities.ReadList>,IReadListReadRepository
    {
        public ReadListReadRepository(LibraryAPIDbContext context) : base(context)
        {
        }
    }
}
