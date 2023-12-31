﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions.Types;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.Library;
using LibraryAPI.Application.Repositories.Book;
using LibraryAPI.Application.Repositories.Library;
using LibraryAPI.Application.ViewModels.Libraries;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Services
{
    public class LibraryService : ILibraryService
    {
        readonly ILibraryReadRepository _libraryReadRepository;
        readonly ILibraryWriteRepository _libraryWriteRepository;
        readonly IBookReadRepository _bookReadRepository;


        public LibraryService(ILibraryReadRepository libraryReadRepository, ILibraryWriteRepository libraryWriteRepository, IBookReadRepository bookReadRepository)
        {
            _libraryReadRepository = libraryReadRepository;
            _libraryWriteRepository = libraryWriteRepository;
            _bookReadRepository = bookReadRepository;
        }

        public async Task<List<Library>> GetAllLibraries()
        {
            List<Library> libraries = await _libraryReadRepository.GetAll(l=>l.Include(l=>l.Books).ThenInclude(b=>b.Authors).Include(l=>l.Books).ThenInclude(b=>b.Librarys)).ToListAsync();
            return libraries;
        }

        public async Task<List<Library>> GetLibrariesByIds(string[] libraryIds)
        {
            List<Library> libraries = new();
            foreach (var libraryId in libraryIds)
            {
                var library = await _libraryReadRepository.GetByIdAsync(libraryId);
                libraries.Add(library);
            }

            return libraries;
        }
        public async Task<Library> CreateLibrary(Library_Create_VM libraryCreateVm)
        {
            if (libraryCreateVm.LibraryBooksId == null)
            {
                throw new ValidationException("Lütfen kitap girişi yapınız");
            }
            List<Book> books = new();
            foreach (var booksId in libraryCreateVm.LibraryBooksId)
            {
                Book libraryBook = await _bookReadRepository.GetByIdAsync(booksId);
                books.Add(libraryBook);
            }
            Library addedLibrary =await _libraryWriteRepository.AddAsync(new()
            {
                Address = libraryCreateVm.Address,
                Name = libraryCreateVm.LibraryName,
                Books = books
            });
            await _libraryWriteRepository.SaveAsync();

            return addedLibrary;

        }
    }
}
