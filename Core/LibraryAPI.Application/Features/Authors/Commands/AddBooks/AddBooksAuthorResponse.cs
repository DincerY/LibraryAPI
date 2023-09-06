using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Features.Authors.Dtos;

namespace LibraryAPI.Application.Features.Authors.Commands.AddBooks;

public class AddBooksAuthorResponse
{
    public string Name { get; set; }
    public string Surname { get; set; }
}