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
using Microsoft.EntityFrameworkCore.Query;

namespace LibraryAPI.Persistence.Services
{
    public class ReadListService : IReadListService
    {
        private readonly IReadListReadRepository _readListReadRepository;
        public ReadListService(IReadListReadRepository readListReadRepository)
        {
            _readListReadRepository = readListReadRepository;
        }


        public async Task<List<ReadList>> GetAllReadListAsync()
        {
           List<ReadList> readLists =await _readListReadRepository.GetAll(r=>r.Include(r=>r.ReadListItems).ThenInclude(rli=>rli.Book).ThenInclude(b=>b.Authors).Include(r=>r.ReadListItems).ThenInclude(rli=>rli.Book).ThenInclude(b=>b.Librarys).Include(r=>r.User)).ToListAsync();
           return readLists;
        }

        public async Task<ReadList> GetUserReadListAsync(string userId)
        {
            ReadList readList = await _readListReadRepository.GetAsync(r => r.UserId == userId,
                r => r.Include(r => r.ReadListItems)
                    .ThenInclude(rli => rli.Book)
                    .ThenInclude(b => b.Librarys)

                    .Include(r => r.ReadListItems)
                    .ThenInclude(rli => rli.Book)
                    .ThenInclude(b => b.Authors)
                    .Include(r => r.User)
            );
            
            return readList;
        }

     

            

      

    }
}
