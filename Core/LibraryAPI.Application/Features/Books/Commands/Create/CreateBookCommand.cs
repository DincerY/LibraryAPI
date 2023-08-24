using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Books.Dtos;
using LibraryAPI.Application.Repositories.Book;
using LibraryAPI.Application.ViewModels.Books;
using LibraryAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LibraryAPI.Application.Features.Books.Commands.Create;

public class CreateBookCommand : IRequest<CreatedBookResponse>
{
    public string Title { get; set; }
    public string PageNumber { get; set; }
    public string Description { get; set; }
    public string[]? AuthorId { get; set; }
    public string[]? LibraryId { get; set; }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand,CreatedBookResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookWriteRepository bookWriteRepository, IMapper mapper, IBookService bookService)
        {
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
            _bookService = bookService;
        }

        public async Task<CreatedBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            Book_Create_VM mappedBookCreateVm = _mapper.Map<Book_Create_VM>(request);

            Book createdbook =await _bookService.CreateBookAsync(mappedBookCreateVm);
            return new CreatedBookResponse()
            {
                PageNumber = createdbook.PageNumber,
                Description = createdbook.Description,
                Title = createdbook.Title,
                Authors = createdbook.Authors.Select(a => new AuthorDto()
                {
                    AuthorSurname = a.Surname,
                    AuthorName = a.Name,
                }).ToArray(),
                Libraries = createdbook.Librarys.Select(l => new LibraryDto()
                {
                    LibraryAddress = l.Address,
                    LibraryName = l.Name,
                }).ToArray(),
                ReadListItems = createdbook.ReadListItems,

            };
        }
    }
}