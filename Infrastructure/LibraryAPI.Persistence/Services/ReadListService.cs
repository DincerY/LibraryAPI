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
            List<ReadList> readLists = await _readListReadRepository
                .GetAll()
                .Include(r => r.ReadListItems)
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

                .ToListAsync();


            ReadList? readList = readLists.Find(x => x.UserId == id);
            return readList;
        }

        public ReadListDto ReadListToReadListDto(ReadList readLists)
        {
            IEnumerable<Book> readListItemBooks = readLists.ReadListItems.Select(r => r.Book).ToArray();
            List<BookDto> books = new();
            BookDto bookDto = new();
            foreach (var book in readListItemBooks)
            {
                bookDto.Id = book.Id;
                bookDto.Description = book.Description;
                bookDto.Title = book.Title;
                bookDto.LibraryName = book.Librarys.Select(l => l.Name).ToArray();
                bookDto.AuthorName = book.Authors.Select(a => a.Name).ToArray();
                bookDto.PageNumber = book.PageNumber;
                books.Add(bookDto);
            }

            ReadListDto dto = new()
            {
                UserId = readLists.UserId,
                Id = readLists.Id,
                ReadListItem = new ReadListItemDto()
                {
                    Book = books
                },
            };
            return dto;
        }

    }
}
