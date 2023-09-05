using LibraryAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.DTOs.ReadList;

namespace LibraryAPI.Application.Features.Libraries.Queries.GetAll;

public class GetAllLibraryResponse
{
    public List<GetAllLibraryDto> GetAllLibraryDtos { get; set; }
}