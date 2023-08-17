using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities.Common;

namespace LibraryAPI.Domain.Entities
{
    public class ReadListItem : BaseEntity
    {
        public Guid BookId { get; set; }
        public Guid ReadListId { get; set; }
        public ReadList ReadList { get; set; }
        public Book Book { get; set; }
    }
}
