using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities.Common;
using LibraryAPI.Domain.Entities.Identity;

namespace LibraryAPI.Domain.Entities
{
    public class ReadList : BaseEntity
    {
        public int UserId { get; set; }
        public AppUser User { get; set; }

    }
}
