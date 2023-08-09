using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Repositories.Author;
using LibraryAPI.Application.Repositories.Book;
using LibraryAPI.Application.Repositories.Library;
using LibraryAPI.Domain.Entities.Identity;
using LibraryAPI.Persistence.Contexts;
using LibraryAPI.Persistence.Repositories.Author;
using LibraryAPI.Persistence.Repositories.Book;
using LibraryAPI.Persistence.Repositories.Library;
using LibraryAPI.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using LibraryAPI.Application.Repositories.ReadList;
using LibraryAPI.Persistence.Repositories.ReadList;

namespace LibraryAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection collection)
        {
            collection.AddDbContext<LibraryAPIDbContext>(options => options.UseSqlServer(Configurations.ConnectionString));

            collection.AddIdentity<AppUser, AppRole>(option =>
            {
                option.Password = new()
                {
                    RequireNonAlphanumeric = false,
                    RequiredLength = 4,
                    RequireLowercase = false,
                    RequireUppercase = false,

                };
            }).AddEntityFrameworkStores<LibraryAPIDbContext>();

            collection.AddScoped<IBookWriteRepository, BookWriteRepository>();
            collection.AddScoped<IBookReadRepository, BookReadRepository>();
            collection.AddScoped<ILibraryReadRepository, LibraryReadRepository>();
            collection.AddScoped<ILibraryWriteRepository, LibraryWriteRepository>();
            collection.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            collection.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();
            collection.AddScoped<IReadListReadRepository, ReadListReadRepository>();
            collection.AddScoped<IReadListWriteRepository, ReadListWriteRepository>();


            collection.AddAutoMapper(Assembly.GetExecutingAssembly());

            collection.AddScoped<IBookService, BookService>();
            collection.AddScoped<IAuthorService, AuthorService>();
            collection.AddScoped<ILibraryService, LibraryService>();
            collection.AddScoped<IUserService, UserService>();
            collection.AddScoped<IAuthService, AuthService>();
            collection.AddScoped<IReadListService, ReadListService>();
            

        }
    }
}
