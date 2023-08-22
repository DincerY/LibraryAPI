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
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public List<ReadListItemDto> ReadListItem { get; set; }
        
    }
}
