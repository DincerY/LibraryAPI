using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.DTOs.Library;
using LibraryAPI.Application.ViewModels.Libraries;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Abstractions.Services
{
    public interface ILibraryService
    {
        Task<List<AllLibrary>> GetAllLibraries();
        Task<List<Library>> GetLibrariesByIds(string[] libraryIds);
        Task<CreateLibraryResponse> CreateLibrary(Library_Create_VM libraryCreateVm);
    }
}
