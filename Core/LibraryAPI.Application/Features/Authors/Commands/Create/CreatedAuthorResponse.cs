using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.Authors.Commands.Create;

public class CreatedAuthorResponse
{
    public string Name { get; set; }
    public string Surname { get; set; }
}