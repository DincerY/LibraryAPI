using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Authors.Rules;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.Authors.Commands.AddBooks;

public class AddBooksAuthorCommand : IRequest<AddBooksAuthorResponse>
{
    public string AuhtorId { get; set; }
    public string[] BookIds { get; set; }

    public class AddBooksAuthorCommandHandler : IRequestHandler<AddBooksAuthorCommand,AddBooksAuthorResponse>
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly AuthorBusinessRule _authorBusinessRule;
        public AddBooksAuthorCommandHandler(IAuthorService authorService, IBookService bookService, AuthorBusinessRule authorBusinessRule)
        {
            _authorService = authorService;
            _bookService = bookService;
            _authorBusinessRule = authorBusinessRule;
        }

        public async Task<AddBooksAuthorResponse> Handle(AddBooksAuthorCommand request, CancellationToken cancellationToken)
        {
            await _authorBusinessRule.AuthorAlreadHasThisBook(request.AuhtorId, request.BookIds);
            List<Book> books =await _bookService.GetBooksByIdsAsync(request.BookIds);
            Author author =await _authorService.GetAuthorsByIdAsync(request.AuhtorId);
            foreach (var book in books)
            {
                author.Books.Add(book);
            }

            AddBooksAuthorResponse response = new()
            {
                Name = author.Name,
                Surname = author.Surname,
            };
            return response;

        }

    }
}