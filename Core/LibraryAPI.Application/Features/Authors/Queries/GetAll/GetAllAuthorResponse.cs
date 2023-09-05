using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Features.Authors.Dtos;

namespace LibraryAPI.Application.Features.Authors.Queries.GetAll;

public class GetAllAuthorResponse
{
    public List<AuthorDto> AuthorDtos { get; set; }
}