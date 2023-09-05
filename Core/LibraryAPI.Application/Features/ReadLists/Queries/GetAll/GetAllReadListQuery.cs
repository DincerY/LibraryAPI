using LibraryAPI.Application.Features.Books.Queries.GetById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.ReadLists.Queries.GetAll;

public class GetAllReadListQuery : IRequest<GetAllReadListReponse>
{
    public class GetAllReadListQueryHandler : IRequestHandler<GetAllReadListQuery, GetAllReadListReponse>
    {
        private readonly IReadListService _readListService;
        public GetAllReadListQueryHandler(IReadListService readListService)
        {
            _readListService = readListService;
        }

        public async Task<GetAllReadListReponse> Handle(GetAllReadListQuery request, CancellationToken cancellationToken)
        {
            List<ReadList> readLists = await _readListService.GetAllReadListAsync();
            GetAllReadListReponse readListReponse = new()
            {
                ReadListDtos = readLists.Select(r=> new ReadListDto()
                {
                    Id = r.Id,
                    ReadListItem = r.ReadListItems.Select(rl => new ReadListItemDto()
                    {
                        ReadListItemId = rl.Id,
                        Book = new BookDto()
                        {
                            Id = rl.Book.Id,
                            PageNumber = rl.Book.PageNumber,
                            Title = rl.Book.Title,
                            Description = rl.Book.Description,
                            Authors = rl.Book.Authors.Select(a => new AuthorDto()
                            {
                                AuthorName = a.Name,
                                AuthorSurname = a.Surname,
                            }).ToArray(),
                            Libraries = rl.Book.Librarys.Select(l => new LibraryDto()
                            {
                                LibraryName = l.Name,
                                LibraryAddress = l.Address,
                            }).ToArray()
                        }
                    }).ToList(),
                    UserName = r.User.Name,
                    UserSurname = r.User.Surname,
                    UserId = r.User.Id,
                })
            };
            return readListReponse;
        }
    }
}   