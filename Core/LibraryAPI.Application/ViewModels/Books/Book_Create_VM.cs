using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.ViewModels.Books
{
    public class Book_Create_VM
    {
        public string? Title { get; set; }
        public string? PageNumber { get; set; }
        public string? Description { get; set; }
        public string[] AuthorId { get; set; }
        public string[] LibraryId { get; set; }

    }
}
