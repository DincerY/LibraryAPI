using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Repositories.Book
{
    public interface IBookWriteRepository : IWriteRepository<Domain.Entities.Book>
    {

    }
}
