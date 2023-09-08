using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Pipelines.Caching;
using LibraryAPI.Application.Repositories.Book;
using LibraryAPI.Application.ViewModels.Books;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.Books.Commands.Create;

public class CreateBookCommand : IRequest<CreatedBookResponse>, ICacheRemoverRequest
{
    public string Title { get; set; }
    public string PageNumber { get; set; }
    public string Description { get; set; }
    public string[]? AuthorId { get; set; }
    public string[]? LibraryId { get; set; }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand,CreatedBookResponse>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        public async Task<CreatedBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            Book_Create_VM mappedBookCreateVm = _mapper.Map<Book_Create_VM>(request);

            Book createdbook =await _bookService.CreateBookAsync(mappedBookCreateVm);
            CreatedBookResponse response = (CreatedBookResponse)Creator.Run(Creator.ResponseType.Created, createdbook);
            return response;
        }
    }

    public string? CacheKey { get; } = "GetAllBookQuery";
    public bool BypassCache { get; } = false;
}