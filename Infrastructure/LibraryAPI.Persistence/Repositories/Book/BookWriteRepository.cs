using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Repositories;
using LibraryAPI.Application.Repositories.Book;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Persistence.Repositories.Book
{
    public class BookWriteRepository : WriteRepository<Domain.Entities.Book>,IBookWriteRepository
    {
        public BookWriteRepository(LibraryAPIDbContext context) : base(context)
        {
        }
    }
}
