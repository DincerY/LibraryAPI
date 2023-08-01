using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Token;
using LibraryAPI.Infrastructure.Token;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.Infrastructure
{
    public static class ServiceRegistration 
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
