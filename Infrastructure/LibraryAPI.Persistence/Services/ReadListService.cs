using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Application.Models;
using LibraryAPI.Application.Repositories.ReadList;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Services
{
    public class ReadListService : IReadListService
    {
        private readonly IReadListReadRepository _readListReadRepository;
        private readonly IMapper _mapper;
        public ReadListService(IReadListReadRepository readListReadRepository, IMapper mapper)
        {
            _readListReadRepository = readListReadRepository;
            _mapper = mapper;
        }

        public async Task<List<ReadList>> GetAsync()
        {
            List<ReadList> readLists = await _readListReadRepository.GetAll().Include(r => r.ReadListItems).Include(r => r.User).ToListAsync();

            return readLists;
            return null;
        }

        public async Task<ReadList> GetUsersReadListAsync(string id)
        {

            List<ReadList> readLists = await _readListReadRepository.GetAll().Include(r => r.ReadListItems).Include(r => r.User).ToListAsync();


            ReadList? readList = readLists.Find(x => x.UserId == id);
            return readList;
            return null;
        }
    }
}
