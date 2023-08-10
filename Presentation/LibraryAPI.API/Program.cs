using FluentValidation.AspNetCore;
using LibraryAPI.Application.Validators.Books;
using LibraryAPI.Infrastructure.Filters;
using LibraryAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Exceptions;
using LibraryAPI.Infrastructure;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();


builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = "localhost:1453";
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,


        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        LifetimeValidator = ( notBefore, expires, securityToken,
                 validationParameters) => expires != null ? expires > DateTime.UtcNow : false
        
    };
});

builder.Services.AddControllers();
//builder.Services.AddControllers(options=>
//    options.Filters.Add<ValidationFilter>()).AddFluentValidation(configuration =>
//    configuration.RegisterValidatorsFromAssemblyContaining<CreateBookValidator>());

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    options.AddPolicy("myclients", builder =>
        builder.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}

app.UseHttpsRedirection();

app.UseCors("myclients");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
