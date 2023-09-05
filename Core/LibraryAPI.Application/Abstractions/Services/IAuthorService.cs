using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.DTOs.Author;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthors();
        public Task<List<Author>> GetAuthorsByIds(string[] AuthorIds);
    }
}
