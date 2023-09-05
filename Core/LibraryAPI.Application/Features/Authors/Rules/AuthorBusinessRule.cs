using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions.Types;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.Authors.Rules;

public class AuthorBusinessRule : BaseBusinessRules
{
    private readonly IBookService _bookService;

    public AuthorBusinessRule(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task BookIdsNotAvailableWhenAuthorInserted(string[] bookIds)
    {
        foreach (var bookId in bookIds)
        {
            Book book = await _bookService.GetBookByIdAsync(bookId);
            if (book == null)
            {
                throw new BusinessException("Bu id de bi kitap mevcut değil");
            }
        }
    }
}