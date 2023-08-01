using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Repositories;
using LibraryAPI.Application.Repositories.Library;
using LibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Repositories.Library
{
    public class LibraryReadRepository :ReadRepository<Domain.Entities.Library>,ILibraryReadRepository
    {
        public LibraryReadRepository(LibraryAPIDbContext context) : base(context)
        {
        }
    }
}
