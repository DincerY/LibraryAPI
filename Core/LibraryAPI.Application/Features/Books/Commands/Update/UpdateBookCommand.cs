using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.Books.Commands.Update
{
    public class UpdateBookCommand : IRequest<UpdatedBookResponse>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand,UpdatedBookResponse>
        {
            private readonly IBookService _bookService;
            private readonly IMapper _mapper;

            public UpdateBookCommandHandler(IBookService bookService, IMapper mapper)
            {
                _bookService = bookService;
                _mapper = mapper;
            }

            public async Task<UpdatedBookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
            {
                Book book =await _bookService.UpdateBookAsync(request.Id.ToString(), request.Description);
                UpdatedBookResponse response =(UpdatedBookResponse)Creator.Run(Creator.ResponseType.Updated,book);
                return response;
            }
        }
    }
}
