using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Authors.Dtos;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.Authors.Queries.GetAll;

public class GetAllAuthorQuery : IRequest<GetAllAuthorResponse>
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery,GetAllAuthorResponse>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public GetAllAuthorQueryHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }
        public async Task<GetAllAuthorResponse> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            List<Author> authors = await _authorService.GetAllAuthors();
            GetAllAuthorResponse response = new()
            {
                AuthorDtos = authors.Select(a=> new AuthorDto()
                {
                    Name = a.Name,
                    Surname = a.Surname,
                }).ToList()
            };
            return response;
        }
    }
}