using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities.Common;

namespace LibraryAPI.Application.Repositories.Book
{
    public interface IBookReadRepository : IReadRepository<Domain.Entities.Book>
    {
        IQueryable<Domain.Entities.Book> GetBooksWithOtherTable();

    }
}
