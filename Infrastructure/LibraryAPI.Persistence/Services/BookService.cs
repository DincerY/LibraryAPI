using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Repositories.Book;
using LibraryAPI.Application.ViewModels.Books;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<object> GetBookByIdAsync(string id)
        {
            Book book =await _bookReadRepository.GetByIdAsync(id);
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


        public async Task<bool> CreateBookAsync(Book_Create_VM bookCreateVm)
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

        public async Task<bool> UpdateBookAsync(string id,string degistirilecek_Veri)
        {
            Book book = await _bookReadRepository.GetByIdAsync(id);
            book.Description = degistirilecek_Veri;
            var result = _bookWriteRepository.Update(book);
            await _bookWriteRepository.SaveAsync();
            return result;
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            Book book =await _bookReadRepository.GetByIdAsync(id);
            var result = _bookWriteRepository.Remove(book);
            await _bookWriteRepository.SaveAsync();
            return result;
            
        }
    }
}
//Her ne kadar guid olsada id arka planda üretilecektir