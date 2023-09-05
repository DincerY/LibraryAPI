using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Application.Features.Books.Queries.GetById;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Features.ReadLists.Queries.GetAll;

public class GetAllReadListReponse 
{
    public IEnumerable<ReadListDto> ReadListDtos { get; set; }
}