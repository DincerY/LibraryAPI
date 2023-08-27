using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Features.Books.Dtos;
using LibraryAPI.Application.Repositories.Book;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.Books.Commands.Delete;

public class DeleteBookCommand : IRequest<DeletedBookResponse>
{
    public Guid Id { get; set; }

    public class DeleteBrandCommadnHandler : IRequestHandler<DeleteBookCommand, DeletedBookResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookReadRepository _bookReadRepository;
        public DeleteBrandCommadnHandler(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
        }

        public async Task<DeletedBookResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book book = await _bookReadRepository.GetByIdAsync(request.Id.ToString());

            Book deletedBook =await _bookWriteRepository.Remove(book);

            DeletedBookResponse response = new()
            {
                PageNumber = deletedBook.PageNumber,
                Title = deletedBook.Title,
                Description = deletedBook.Description,
                Libraries = deletedBook?.Librarys.Select(l=>new LibraryDto()
                {
                    LibraryAddress = l.Address,
                    LibraryName = l.Name
                }).ToArray(),
                Authors = deletedBook?.Authors.Select(a=>new AuthorDto()
                {
                    AuthorSurname = a.Surname,
                    AuthorName = a.Name,
                }).ToArray()
            };
            return response;

        }
    }
}