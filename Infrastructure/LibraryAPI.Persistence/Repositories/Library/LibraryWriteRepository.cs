using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Repositories.Library;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Persistence.Repositories.Library
{
    public class LibraryWriteRepository :  WriteRepository<Domain.Entities.Library>,ILibraryWriteRepository
    {
        public LibraryWriteRepository(LibraryAPIDbContext context) : base(context)
        {
        }
    }
}
