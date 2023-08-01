using LibraryAPI.Application.Repositories.Book;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Persistence.Repositories.Book
{
    public class BookReadRepository : ReadRepository<Domain.Entities.Book>,IBookReadRepository
    {
        readonly LibraryAPIDbContext _context;
        public BookReadRepository(LibraryAPIDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Domain.Entities.Book> GetBooksWithOtherTable()
        {
            //_context.Books.Where(b => b.Authors.Any(a => a.Books.Any(b => b.Id == Guid.Parse(id))));
            return _context.Books.Include(b => b.Authors).Include(b => b.Librarys);


        }
    }
}
