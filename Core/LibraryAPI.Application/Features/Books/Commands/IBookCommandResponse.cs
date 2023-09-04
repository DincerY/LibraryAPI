using LibraryAPI.Application.Features.Books.Commands.Create;
using LibraryAPI.Application.Features.Books.Commands.Delete;
using LibraryAPI.Application.Features.Books.Commands.Update;
using LibraryAPI.Application.Features.Books.Dtos;
using LibraryAPI.Application.Features.Books.Queries.GetById;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.Books.Commands;

public interface IBookResponse
{
}

public interface IBookResponseFactory
{
    IBookResponse Create(Book book);
}

public class CreatedBookResponseFactory : IBookResponseFactory
{
    public IBookResponse Create(Book createdBook)
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

public class DeletedBookResponseFactory : IBookResponseFactory
{
    public IBookResponse Create(Book deletedBook)
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

public class UpdatedBookResponseFactory : IBookResponseFactory
{
    public IBookResponse Create(Book updatedBook)
    {

        UpdatedBookResponse response = new()
        {
            Id = updatedBook.Id,
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

public class GetByIdBookResponseFactory : IBookResponseFactory
{
    public IBookResponse Create(Book updatedBook)
    {

        GetByIdBookResponse response = new()
        {
            Id = updatedBook.Id,
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
        Updated,
        GetById
    }

    public static IBookResponse Run(ResponseType responseType,Book book)
    {
        IBookResponseFactory responseFactory = responseType switch
        {
            ResponseType.Created => new CreatedBookResponseFactory(),
            ResponseType.Deleted => new DeletedBookResponseFactory(),
            ResponseType.Updated => new UpdatedBookResponseFactory(),
            ResponseType.GetById => new GetByIdBookResponseFactory()

        };
        

        return responseFactory.Create(book);
    }
}