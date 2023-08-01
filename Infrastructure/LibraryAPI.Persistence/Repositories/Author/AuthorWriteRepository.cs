using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Repositories.Author;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Persistence.Repositories.Author
{
    public class AuthorWriteRepository : WriteRepository<Domain.Entities.Author>,IAuthorWriteRepository
    {
        public AuthorWriteRepository(LibraryAPIDbContext context) : base(context)
        {
        }
    }
}
