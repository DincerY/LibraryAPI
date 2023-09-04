using LibraryAPI.Application.Features.Books.Commands.Create;
using LibraryAPI.Application.Features.Books.Commands.Delete;
using LibraryAPI.Application.Features.Books.Commands.Update;
using LibraryAPI.Application.Features.Books.Dtos;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.Books.Commands;

public interface IBookCommandResponse
{
}

public interface IBookCommandResponseFactory
{
    IBookCommandResponse Create(Book book);
}

public class CreatedBookResponseFactory : IBookCommandResponseFactory
{
    public IBookCommandResponse Create(Book createdBook)
    {
        CreatedBookResponse response = new()
        {
            PageNumber = createdBook.PageNumber,
            Description = createdBook.Description,
            Title = createdBook.Title,
            Authors = createdBook.Authors.Select(a => new AuthorDto()
            {
                AuthorSurname = a.Surname,
                AuthorName = a.Name,
            }).ToArray(),
            Libraries = createdBook.Librarys.Select(l => new LibraryDto()
            {
                LibraryAddress = l.Address,
                LibraryName = l.Name,
            }).ToArray(),
            ReadListItems = createdBook.ReadListItems
        };
        return response;
    }
}

public class DeletedBookResponseFactory : IBookCommandResponseFactory
{
    public IBookCommandResponse Create(Book deletedBook)
    {
        DeletedBookResponse response = new()
        {
            PageNumber = deletedBook.PageNumber,
            Description = deletedBook.Description,
            Title = deletedBook.Title,
            Authors = deletedBook.Authors.Select(a => new AuthorDto()
            {
                AuthorSurname = a.Surname,
                AuthorName = a.Name,
            }).ToArray(),
            Libraries = deletedBook.Librarys.Select(l => new LibraryDto()
            {
                LibraryAddress = l.Address,
                LibraryName = l.Name,
            }).ToArray(),
            ReadListItems = deletedBook.ReadListItems
        };
        return response;
    }
}

public class UpdatedBookResponseFactory : IBookCommandResponseFactory
{
    public IBookCommandResponse Create(Book updatedBook)
    {

        UpdatedBookResponse response = new()
        {
            PageNumber = updatedBook.PageNumber,
            Description = updatedBook.Description,
            Title = updatedBook.Title,
            Authors = updatedBook.Authors.Select(a => new AuthorDto()
            {
                AuthorSurname = a.Surname,
                AuthorName = a.Name,
            }).ToArray(),
            Libraries = updatedBook.Librarys.Select(l => new LibraryDto()
            {
                LibraryAddress = l.Address,
                LibraryName = l.Name,
            }).ToArray(),
            ReadListItems = updatedBook.ReadListItems
        };
        return response;
    }
}

public class Creator
{
    public enum ResponseType
    {
        Created,
        Deleted,
        Updated
    }

    public static IBookCommandResponse Run(ResponseType responseType,Book book)
    {
        IBookCommandResponseFactory responseFactory = responseType switch
        {
            ResponseType.Created => new CreatedBookResponseFactory(),
            ResponseType.Deleted => new DeletedBookResponseFactory(),
            ResponseType.Updated => new UpdatedBookResponseFactory(),

        };
        

        return responseFactory.Create(book);
    }
}