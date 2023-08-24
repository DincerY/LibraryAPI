using LibraryAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Features.Books.Dtos;

namespace LibraryAPI.Application.Features.Books.Commands.Create;

public class CreatedBookResponse
{
    public string PageNumber { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public LibraryDto[]? Libraries { get; set; }
    public AuthorDto[]? Authors { get; set; }
    public ICollection<ReadListItem> ReadListItems { get; set; }
}