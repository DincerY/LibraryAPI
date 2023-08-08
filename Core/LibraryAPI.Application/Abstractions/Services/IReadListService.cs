using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Abstractions.Services
{
    public interface IReadListService
    {
        public List<ReadList> Get();
        public Task<ReadList> GetUsersReadList(string id);
    }
}
