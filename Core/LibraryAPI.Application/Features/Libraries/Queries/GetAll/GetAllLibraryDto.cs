using LibraryAPI.Application.DTOs.ReadList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.Libraries.Queries.GetAll;

public class GetAllLibraryDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public ICollection<BookDto> Books { get; set; }
}