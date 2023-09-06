using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.Author;
using LibraryAPI.Application.Features.Authors.Commands.Create;
using LibraryAPI.Application.Repositories.Author;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Services
{
    public class AuthorService : IAuthorService
    {
        readonly IAuthorReadRepository _authorReadRepository;
        readonly IAuthorWriteRepository _authorWriteRepository;
        readonly IBookService _bookService;
        public AuthorService(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            var result = await _authorReadRepository.GetAll().ToListAsync();
            return result;
        }

        public async Task<List<Author>> GetAuthorsByIdsAsync(string[] authorIds)
        {
            List<Author> authors = new();
            foreach (var authorId in authorIds)
            {
                var deneme = await _authorReadRepository.GetByIdAsync(authorId);
                authors.Add(deneme);
            }
            return authors;
        }

        public async Task<Author> CreateAuthor(CreateAuthorCommand command)
        {
            List<Book> books = await _bookService.GetBooksByIdsAsync(command.BookIds);
            Author author = new()
            {
                Name = command.Name,
                Surname = command.Surname,
                Books = books
            };
             Author addedAuthor = await _authorWriteRepository.AddAsync(author);
             return addedAuthor;
        }

        public async Task<Author> GetAuthorsByIdAsync(string authorId)
        {
            Author author =await _authorReadRepository.GetAsync(a => a.Id == Guid.Parse(authorId),a=>a.Include(a=>a.Books));
            return author;
        }
    }
}
