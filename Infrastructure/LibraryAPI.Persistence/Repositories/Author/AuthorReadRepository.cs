using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Repositories.Author;
using LibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Repositories.Author
{
    public class AuthorReadRepository : ReadRepository<Domain.Entities.Author>,IAuthorReadRepository
    {

        public AuthorReadRepository(LibraryAPIDbContext context) : base(context)
        {
        }

        //public async Task<List<Domain.Entities.Author>> GetAuthorListByIds(string[] AuthorIds)
        //{
        //    Domain.Entities.Author[] authorArray = null;
        //    List<Domain.Entities.Author>? authors = null;
        //    foreach (var authorId in AuthorIds)
        //    {
        //        var author = await Table.Where(a => a.Id == Guid.Parse(authorId)).ToArrayAsync();
        //        foreach (var author1 in author)
        //        {
        //            authors.Add(author1);
        //        }

        //    }
        //    return authors;
             
        //}
       

    }
}
