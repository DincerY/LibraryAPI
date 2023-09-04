using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Books.Commands;
using LibraryAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Features.Books.Queries.GetById
{
    public class GetByIdBookQuery : IRequest<GetByIdBookResponse>
    {
        public Guid Id { get; set; }

        public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery,GetByIdBookResponse>
        {
            private readonly IBookService _bookService;
            public GetByIdBookQueryHandler(IBookService bookService)
            {
                _bookService = bookService;
            }

            public async Task<GetByIdBookResponse> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
            {
                Book book = await _bookService.GetBookByIdAsync(request.Id.ToString(),b=>b.Include(b=>b.Authors).Include(b=>b.Librarys));
                GetByIdBookResponse response = (GetByIdBookResponse)Creator.Run(Creator.ResponseType.GetById,book);
                return response;
            }
        }
    }
}
    