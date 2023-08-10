using LibraryAPI.Domain.Entities.Identity;
using LibraryAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.DTOs.ReadList
{
    public class ReadListDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Guid ReadListItemId { get; set; }
        
    }
}
