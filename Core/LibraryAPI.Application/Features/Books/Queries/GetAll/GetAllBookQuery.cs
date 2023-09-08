using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Books.Dtos;
using LibraryAPI.Application.Pipelines.Caching;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.Books.Queries.GetAll
{
    public class GetAllBookQuery : IRequest<List<GetAllBookResponse>>, ICachableRequest
    {
        public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery,List<GetAllBookResponse>>
        {
            private readonly IBookService _bookService;

            public GetAllBookQueryHandler(IBookService bookService)
            {
                _bookService = bookService;
            }

            public async Task<List<GetAllBookResponse>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
            {
                List<Book> books = await _bookService.GetAllBooksAsync();
                List<GetAllBookResponse> allBooks = new();
                foreach (Book book in books)
                {
                    GetAllBookResponse response = new()
                    {
                        Id = book.Id,
                        PageNumber = book.PageNumber,
                        Description = book.Description,
                        Title = book.Title,
                        Authors = book.Authors.Select(a => new AuthorDto()
                        {
                            AuthorSurname = a.Surname,
                            AuthorName = a.Name,
                        }).ToArray(),
                        Libraries = book.Librarys.Select(l => new LibraryDto()
                        {
                            LibraryAddress = l.Address,
                            LibraryName = l.Name,
                        }).ToArray(),
                        ReadListItems = book.ReadListItems
                    };
                    allBooks.Add(response);
                }
                return allBooks;
            }
        }

        public string CacheKey => "GetAllBookQuery";
        public bool ByPassCache { get; }
        public TimeSpan? SlidingExpiration { get; } = TimeSpan.Parse("2");
    }
}
