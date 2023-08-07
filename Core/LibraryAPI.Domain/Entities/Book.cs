﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities.Common;

namespace LibraryAPI.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string PageNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Library> Librarys { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<ReadListItem> ReadListItems { get; set; }
    }
}
