using Exceptions.Types;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.Authors.Rules;

public class AuthorBusinessRule : BaseBusinessRules
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;

    public AuthorBusinessRule(IBookService bookService, IAuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

    public async Task BookIdsNotAvailableWhenAuthorInserted(string[] bookIds)
    {
        foreach (var bookId in bookIds)
        {
            Book book = await _bookService.GetBookByIdAsync(bookId);
            if (book == null)
            {
                throw new BusinessException("Bazı idlere ait kitap bulunamamaktadır");
            }
        }
    }
    public async Task AuthorAlreadHasThisBook(string authorId,string[] bookIds)
    {
        foreach (var bookId in bookIds)
        {
            Author author = await _authorService.GetAuthorsByIdAsync(authorId);
            foreach (var id in bookIds)
            {
                if (author.Books.All(b => b.Id != Guid.Parse(id)))
                {
                    throw new BusinessException("Bazı idlere ait kitap bulunamamaktadır");
                }

            }

        }
    }
}