using backend_api.Business.Abstracts;
using backend_api.Business.Concretes;
using backend_api.DataAccess.Abstracts;
using backend_api.DataAccess.Concretes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//student
builder.Services.AddSingleton<IStudentManager, StudentManager>();
builder.Services.AddSingleton<IStudentDal, StudentDalInDb>();
//temel kayýt ekle
builder.Services.AddSingleton<IOyuncuKayitTemelBilgilerManager,OyuncuKayitTemelBilgilerManager>();
builder.Services.AddSingleton<IOyuncuKayitTemelBilgiler,OyuncuKayitTemelBilgiler>();


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
