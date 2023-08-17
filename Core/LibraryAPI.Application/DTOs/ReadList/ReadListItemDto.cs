using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.DTOs.ReadList
{
    public class ReadListItemDto
    {
        public IEnumerable<BookDto> Book { get; set; }
    }
}
