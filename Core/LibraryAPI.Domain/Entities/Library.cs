using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities.Common;

namespace LibraryAPI.Domain.Entities
{
    public class Library : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; } 
        public ICollection<Book> Books { get; set; }

    }
}
