using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Features.Books;
using LibraryAPI.Application.ViewModels.Books;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Abstractions.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(string id);
        Task<List<Book>> GetBooksByIdsAsync(string[] ids);
        Task<Book> CreateBookAsync(Book_Create_VM bookCreateVm);
        Task<Book> UpdateBookAsync(string id, string description);

        Task<bool> DeleteBookAsync(string id);



        public Task<Book> Deneme(Guid id);
    }
}
