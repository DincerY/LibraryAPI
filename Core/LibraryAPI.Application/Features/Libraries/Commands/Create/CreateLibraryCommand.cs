using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.ViewModels.Libraries;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.Libraries.Commands.Create
{
    public class CreateLibraryCommand : IRequest<CreatedLibraryResponse>
    {
        public string Address { get; set; }
        public string LibraryName { get; set; }
        public string[] LibraryBooksId { get; set; }

        public class CreateLibraryCommandHandler : IRequestHandler<CreateLibraryCommand,CreatedLibraryResponse>
        {
            private readonly ILibraryService _libraryService;
            private readonly IMapper _mapper;

            public CreateLibraryCommandHandler(ILibraryService libraryService, IMapper mapper)
            {
                _libraryService = libraryService;
                _mapper = mapper;
            }

            public async Task<CreatedLibraryResponse> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
            {
                Library_Create_VM mappedLibraryCreateVm = _mapper.Map<Library_Create_VM>(request);
                Library addedLibrary =await _libraryService.CreateLibrary(mappedLibraryCreateVm);
                CreatedLibraryResponse response = _mapper.Map<CreatedLibraryResponse>(addedLibrary);
                return response;
            }
        }
    }
}
