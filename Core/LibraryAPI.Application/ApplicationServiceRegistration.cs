using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LibraryAPI.Application.Features.Authors.Rules;
using LibraryAPI.Application.Pipelines.Caching;
using LibraryAPI.Application.Pipelines.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            cfg.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(CachingBehavior<,>));
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        services.AddScoped<AuthorBusinessRule>();

        return services;
    }
}