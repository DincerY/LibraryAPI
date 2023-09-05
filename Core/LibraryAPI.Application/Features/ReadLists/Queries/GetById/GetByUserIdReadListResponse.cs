using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.DTOs.ReadList;

namespace LibraryAPI.Application.Features.ReadLists.Queries.GetById;

public class GetByUserIdReadListResponse
{
    public ReadListDto ReadListDto { get; set; }
}