using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.Author;
using LibraryAPI.Application.Repositories.Author;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Services
{
    public class AuthorService : IAuthorService
    {
        readonly IAuthorReadRepository _authorReadRepository;

        public AuthorService(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }

        public async Task<List<AllAuthor>> GetAllAuthors()
        {
            var result = await _authorReadRepository.GetAll().Select(a=> new AllAuthor()
            {
                Id = a.Id.ToString(),
                Name = a.Name,
                Surname = a.Surname,
            }).ToListAsync();
            return result;
        }

        public async Task<List<Author>> GetAuthorsByIds(string[] AuthorIds)
        {
            List<Author> authors = new();
            foreach (var authorId in AuthorIds)
            {
                var deneme = await _authorReadRepository.GetByIdAsync(authorId);
                authors.Add(deneme);
            }
            return authors;
        }

    }
}
