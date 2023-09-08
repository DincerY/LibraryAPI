using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Application.Repositories.Library;
using LibraryAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Features.Libraries.Queries.GetAll;

public class GetAllLibraryQuery :  IRequest<GetAllLibraryResponse>
{
    public class GetAllLibraryQueryHandler : IRequestHandler<GetAllLibraryQuery,GetAllLibraryResponse>
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly ILibraryService _libraryService;

        public GetAllLibraryQueryHandler(ILibraryReadRepository libraryReadRepository, ILibraryService libraryService)
        {
            _libraryReadRepository = libraryReadRepository;
            _libraryService = libraryService;
        }

        public async Task<GetAllLibraryResponse> Handle(GetAllLibraryQuery request, CancellationToken cancellationToken)
        {
            List<Library> libraries = await _libraryService.GetAllLibraries();
            List<GetAllLibraryDto> getAllLibraryDtos = new();
            foreach (var library in libraries)
            {
                GetAllLibraryDto getAllLibraryDto = new()
                {
                    Id = library.Id,
                    Address = library.Address,
                    Books = library.Books.Select(b=> new BookDto()
                    {
                        Id = b.Id,
                        Description = b.Description,
                        Title = b.Title,
                        PageNumber = b.PageNumber,
                        Authors = b.Authors.Select(a=> new AuthorDto(){AuthorName = a.Name, AuthorSurname = a.Surname}).ToArray(),
                        Libraries = b.Librarys.Select(l=> new LibraryDto()
                        {
                            LibraryAddress = l.Address,
                            LibraryName = l.Name
                        }).ToArray()
                    }).ToList(),
                    Name = library.Name,
                };
                getAllLibraryDtos.Add(getAllLibraryDto);
            }

            GetAllLibraryResponse response = new()
            {
                GetAllLibraryDtos = getAllLibraryDtos
            };
            return response;
        }
    }
}