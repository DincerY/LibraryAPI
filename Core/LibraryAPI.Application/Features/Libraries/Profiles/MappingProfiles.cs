using AutoMapper;
using LibraryAPI.Application.Features.Libraries.Commands.Create;
using LibraryAPI.Application.ViewModels.Libraries;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.Libraries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Library, CreatedLibraryResponse>().ReverseMap();
        CreateMap<CreateLibraryCommand, Library_Create_VM>().ReverseMap();
    }
}
