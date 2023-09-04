using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Books;
using LibraryAPI.Application.Features.Books.Dtos;
using LibraryAPI.Application.Repositories.Book;
using LibraryAPI.Application.ViewModels.Books;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LibraryAPI.Persistence.Services
{
    public class BookService : IBookService
    {
        readonly IBookReadRepository _bookReadRepository;
        readonly IBookWriteRepository _bookWriteRepository;
        readonly IAuthorService _authorService;
        readonly ILibraryService _libraryService;
        public BookService(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository,IAuthorService authorService, ILibraryService libraryService)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _authorService = authorService;
            _libraryService = libraryService;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            List<Book> books = await _bookReadRepository.GetBooksWithOtherTable().ToListAsync();
            return books;
        }

        public async Task<Book> GetBookByIdAsync(string id,
            Func<IQueryable<Book>, IIncludableQueryable<Book, object>>? include = null)
        {
            Book book =await _bookReadRepository.GetByIdAsync(id,include);
            return book;
        }

        public async Task<List<Book>> GetBooksByIdsAsync(string[] ids)
        {
            List<Book> books = new();
            foreach (string id in ids)
            {
                var temporaryData = await _bookReadRepository.GetByIdAsync(id);
                books.Add(temporaryData);
            }
            return books;
        }

        public Task<bool> DeleteBookAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> Deneme(Guid id)
        {
            Book book = await _bookReadRepository.GetAsync(b => b.Id == id,
                include: b => b.Include(b => b.Librarys).Include(b => b.Authors));
            return book;
        }


        public async Task<Book> CreateBookAsync(Book_Create_VM bookCreateVm)
        {
            List<Library>? libraries = await _libraryService.GetLibrariesByIds(bookCreateVm.LibraryId);
            List<Author>? authors = await _authorService.GetAuthorsByIds(bookCreateVm.AuthorId);
            var result = await _bookWriteRepository.AddAsync(new()
            {
                Authors = authors,
                Librarys = libraries,
                Title = bookCreateVm.Title,
                Description = bookCreateVm.Description,
                PageNumber = bookCreateVm.PageNumber,
            });
             await _bookWriteRepository.SaveAsync();
             return result;
        }

        public async Task<Book> UpdateBookAsync(string id,string description)
        {
            Book book = await _bookReadRepository.GetByIdAsync(id,b=>b.Include(b=>b.Authors).Include(b=>b.Librarys));
            book.Description = description;
            Book updatedBook = _bookWriteRepository.Update(book);
            await _bookWriteRepository.SaveAsync();
            return updatedBook;
        }



        //public async Task<bool> DeleteBookAsync(string id)
        //{
        //    Book book =await _bookReadRepository.GetByIdAsync(id);
        //    var result = _bookWriteRepository.Remove(book);
        //    await _bookWriteRepository.SaveAsync();
        //    return result;
            
        //}
    }
}
//Her ne kadar guid olsada id arka planda üretilecektir