using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Repositories.ReadList;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Persistence.Services
{
    public class ReadListService : IReadListService
    {
        private readonly IReadListReadRepository _readListReadRepository;
        public ReadListService(IReadListReadRepository readListReadRepository)
        {
            _readListReadRepository = readListReadRepository;
        }

        public List<ReadList> Get()
        {
            List<ReadList> readLists = _readListReadRepository.GetAll().ToList();
            return readLists;
        }

        public Task<ReadList> GetUsersReadList(string id)
        {
            throw new NotImplementedException();
        }
    }
}
