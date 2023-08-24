﻿using System;
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
        public ReadListService(IReadListReadRepository readListReadRepository)
        {
            _readListReadRepository = readListReadRepository;
        }

        public async Task<List<ReadList>> GetAsync()
        {
            List<ReadList> readLists = await _readListReadRepository
                .GetAll()
                .Include(r => r.ReadListItems)
                .ThenInclude(rli=>rli.Book).ThenInclude(b=>b.Authors)
                .Include(r => r.ReadListItems)
                .ThenInclude(rli => rli.Book).ThenInclude(b => b.Librarys)
                .Include(r=>r.User)
                .ToListAsync();

            return readLists;
        }

        public async Task<ReadList> GetUsersReadListAsync(string id)
        {

            List<ReadList> readLists = await _readListReadRepository
                .GetAll()
                .Include(r => r.ReadListItems)
                .ThenInclude(rli=>rli.Book)
                .ThenInclude(b=>b.Librarys)


                .Include(r => r.ReadListItems)
                .ThenInclude(rli => rli.Book)
                .ThenInclude(b => b.Authors)

                .Include(rl=>rl.User)

                .ToListAsync();


            ReadList? readList = readLists.Find(x => x.UserId == id);
            return readList;
        }

      

    }
}
