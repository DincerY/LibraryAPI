using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Repositories.ReadList;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Persistence.Repositories.ReadList
{
    public class ReadListWriteRepository : WriteRepository<Domain.Entities.ReadList>, IReadListWriteRepository
    {
        public ReadListWriteRepository(LibraryAPIDbContext context) : base(context)
        {
        }
    }
}
