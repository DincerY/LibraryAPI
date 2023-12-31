﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.DTOs.ReadList
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string PageNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorDto[] Authors { get; set; }
        public LibraryDto[] Libraries { get; set; }
    }
}
