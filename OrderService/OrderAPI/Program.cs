using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Consumers;
using OrderAPI.Models;
using OrderAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<ReadListFinishedEventConsumer>();

    configurator.UsingRabbitMq((context, _configurator) =>
    {
        _configurator.Host("amqps://gyakepie:WMp2RPFSDqksndUbsWHF8PcpsBPL5NQI@stingray.rmq.cloudamqp.com/gyakepie");

        _configurator.ReceiveEndpoint("order_readlist_finished_event_queue",e=>e.ConfigureConsumer<ReadListFinishedEventConsumer>(context));
    });
});

builder.Services.AddDbContext<OrderAPIDbContext>(option =>
{
    option.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookOrderAPIDb;Trusted_Connection=True;");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
