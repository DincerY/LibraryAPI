using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.ViewModels.Books;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Abstractions.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<object> GetBookByIdAsync(string id);
        Task<List<Book>> GetBooksByIdsAsync(string[] ids);
        Task<bool> CreateBookAsync(Book_Create_VM bookCreateVm);
        Task<bool> UpdateBookAsync(string id, string degistirilecek_Veri);

        Task<bool> DeleteBookAsync(string id);
    }
}
