using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.Books.Commands.Create;

public class CreatedBookResponse
{
    public string Title { get; set; }
    public string PageNumber { get; set; }
    public string Description { get; set; }
    public string[]? AuthorId { get; set; }
    public string[]? LibraryId { get; set; }
}