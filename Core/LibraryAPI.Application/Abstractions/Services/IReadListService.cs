using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Abstractions.Services
{
    public interface IReadListService
    {
        public Task<List<ReadList>> GetAsync();
        public Task<ReadList> GetUsersReadListAsync(string id);
    }
}
