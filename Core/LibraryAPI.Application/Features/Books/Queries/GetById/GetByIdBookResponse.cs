using LibraryAPI.Application.Features.Books.Commands;
using LibraryAPI.Application.Features.Books.Dtos;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.Books.Queries.GetById
{
    public class GetByIdBookResponse : IBookResponse
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
