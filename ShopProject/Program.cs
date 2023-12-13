using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopProject.Converters;
using ShopProject.Converters.Interfaces;
using ShopProject.EF;
using ShopProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionStr = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ShopProjectDbContext>(x => x.UseSqlServer(connectionStr));

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<IShopProjectUnitOfWork, ShopProjectUnitOfWork>();
builder.Services.AddScoped<IUserConverter, UserConverter>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
