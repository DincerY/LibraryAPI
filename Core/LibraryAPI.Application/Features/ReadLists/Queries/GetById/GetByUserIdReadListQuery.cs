using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.ReadLists.Queries.GetById;

public class GetByUserIdReadListQuery : IRequest<GetByUserIdReadListResponse>
{
    public Guid UserId { get; set; }
    public class GetByUserIdReadListQueryHandler : IRequestHandler<GetByUserIdReadListQuery,GetByUserIdReadListResponse>
    {
        private readonly IReadListService _readListService;
        public GetByUserIdReadListQueryHandler(IReadListService readListService)
        {
            _readListService = readListService;
        }

        public async Task<GetByUserIdReadListResponse> Handle(GetByUserIdReadListQuery request, CancellationToken cancellationToken)
        {
            ReadList readList = await _readListService.GetUserReadListAsync(request.UserId.ToString());
            return new GetByUserIdReadListResponse
            {
                ReadListDto = new ReadListDto
                {
                    Id = readList.Id,
                    UserId = readList.UserId,
                    UserName = readList.User.Name,
                    UserSurname = readList.User.Surname,
                    ReadListItem = readList.ReadListItems.Select(rli => new ReadListItemDto()
                    {
                        ReadListItemId = rli.Id,
                        Book = new BookDto()
                        {
                            Id = rli.Book.Id,
                            Description = rli.Book.Description,
                            PageNumber = rli.Book.PageNumber,
                            Title = rli.Book.Title,
                            Authors = rli.Book.Authors.Select(a => new AuthorDto()
                            {
                                AuthorName = a.Name,
                                AuthorSurname = a.Surname,
                            }).ToArray(),
                            Libraries = rli.Book.Librarys.Select(l => new LibraryDto()
                            {
                                LibraryName = l.Name,
                                LibraryAddress = l.Address,
                            }).ToArray()
                        }
                    }).ToList()
                }
            };
            
        }
    }
}