using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.Books.Queries.GetAll
{
    public class GetAllBookQuery : IRequest<List<GetAllBookResponse>>
    {
        public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery,List<GetAllBookResponse>>
        {
            private readonly IBookService _bookService;
            private readonly IMapper _mapper;
            public GetAllBookQueryHandler(IBookService bookService, IMapper mapper)
            {
                _bookService = bookService;
                _mapper = mapper;
            }

            public async Task<List<GetAllBookResponse>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
            {
                List<Book> books = await _bookService.GetAllBooksAsync();
                List<GetAllBookResponse> allBooks = new();
                foreach (Book book in books)
                {
                    GetAllBookResponse response = _mapper.Map<GetAllBookResponse>(book);
                    allBooks.Add(response);
                }
                return allBooks;
            }
        }
    }
}
