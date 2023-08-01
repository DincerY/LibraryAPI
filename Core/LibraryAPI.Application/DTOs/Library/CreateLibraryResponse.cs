using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.DTOs.Library
{
    public class CreateLibraryResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
