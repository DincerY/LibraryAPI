using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.Common;
using LibraryAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Contexts
{
    public class LibraryAPIDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public LibraryAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }  
        public DbSet<Library> Librarys { get; set; }
        public DbSet<Author> Author { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entities =ChangeTracker.Entries();
            foreach (var entityEntry in entities)
            {
                if (entityEntry.Entity is BaseEntity entity)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedDate = DateTime.UtcNow;
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
