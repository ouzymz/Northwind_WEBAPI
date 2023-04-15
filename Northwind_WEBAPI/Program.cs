using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Northwind_WEBAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(
    x => x.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddControllers();

builder.Services.AddDbContext<NorthwindContext>
    (
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Northwind"))
    );

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

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
