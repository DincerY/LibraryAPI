using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.DTOs.Author;
using LibraryAPI.Application.Features.Authors.Commands.Create;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthors();
        public Task<List<Author>> GetAuthorsByIdsAsync(string[] authorIds);

        public Task<Author> CreateAuthor(CreateAuthorCommand command);
        public Task<Author> GetAuthorsByIdAsync(string authorId);

    }
}
