﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Application.Features.Books.Commands.Create;
using LibraryAPI.Application.ViewModels.Books;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.Books.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBookCommand, Book_Create_VM>().ReverseMap();


    }
}