using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.DTOs.Library
{
    public class AllLibrary
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
