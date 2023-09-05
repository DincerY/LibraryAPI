using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Authors.Rules;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.Authors.Commands.Create;

public class CreateAuthorCommand : IRequest<CreatedAuthorResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string[] BookIds { get; set; }
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand,CreatedAuthorResponse>
    {
        private readonly IAuthorService _authorService;
        private readonly AuthorBusinessRule _authorBusinessRule;
        public CreateAuthorCommandHandler(IAuthorService authorService, AuthorBusinessRule authorBusinessRule)
        {
            _authorService = authorService;
            _authorBusinessRule = authorBusinessRule;
        }

        public async Task<CreatedAuthorResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _authorBusinessRule.BookIdsNotAvailableWhenAuthorInserted(request.BookIds);
            Author addedAuthor = await _authorService.CreateAuthor(request);
            CreatedAuthorResponse response = new()
            {
                Name = addedAuthor.Name,
                Surname = addedAuthor.Surname,
            };
            return response;
        }
    }
}