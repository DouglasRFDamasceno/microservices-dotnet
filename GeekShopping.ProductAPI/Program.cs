using AutoMapper;
using GeekShopping.ProductAPI.Config;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("MySQLConnectionString");
builder.Services.AddDbContext<MySQLContext>
    (opts =>
    {
        opts.UseMySql(connString, ServerVersion.AutoDetect(connString));
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MySQLContext>();
    db.Database.Migrate();
}

app.Run();
