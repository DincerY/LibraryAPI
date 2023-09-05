using LibraryAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.Libraries.Commands.Create
{
    public class CreatedLibraryResponse
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
