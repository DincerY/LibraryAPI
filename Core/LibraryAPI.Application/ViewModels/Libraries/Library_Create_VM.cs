using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.ViewModels.Libraries
{
    public class Library_Create_VM
    {
        public string Address { get; set; }
        public string LibraryName { get; set; }
        public string[] LibraryBooksId { get; set; }
    }
}
