using Exceptions.Extensions;
using LibraryAPI.API.Extensions;
using LibraryAPI.Application;
using LibraryAPI.Infrastructure;
using LibraryAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using LibraryAPI.API.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerAuthExtension();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<OrderFinishedEventConsumer>();

    configurator.UsingRabbitMq((context, _configurator) =>
    {
        _configurator.Host("amqps://gyakepie:WMp2RPFSDqksndUbsWHF8PcpsBPL5NQI@stingray.rmq.cloudamqp.com/gyakepie");

        _configurator.ReceiveEndpoint("library_order_finished_event_queue", con =>
            con.ConfigureConsumer<OrderFinishedEventConsumer>(context)
            );
    });

    
});

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

//if (app.Environment.IsDevelopment())
//{
//    app.ConfigureCustomExceptionMiddleware();
//}

app.UseHttpsRedirection();

app.UseCors("myclients");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
