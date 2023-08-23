using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Application.Repositories.Book;
using LibraryAPI.Domain.Entities;
using MediatR;

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
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookWriteRepository bookWriteRepository, IMapper mapper)
        {
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreatedBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request);
            bool response = await _bookWriteRepository.AddAsync(book);
            return new CreatedBookResponse()
            {
                //response burda direk kitabı dönücez
            };
        }
    }
}