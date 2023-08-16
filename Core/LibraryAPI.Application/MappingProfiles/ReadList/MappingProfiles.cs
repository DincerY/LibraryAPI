using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Application.Models;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.MappingProfiles.ReadList
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<List<Domain.Entities.ReadList>, List<ReadListDto>>().ReverseMap();

        }
    }
}
