using LibraryAPI.Application.Features.Books.Dtos;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.Books.Queries.GetAll
{
    public class GetAllBookResponse
    {
        public Guid Id { get; set; }
        public string PageNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public LibraryDto[]? Libraries { get; set; }
        public AuthorDto[]? Authors { get; set; }
        public ICollection<ReadListItem> ReadListItems { get; set; }
    }
}
