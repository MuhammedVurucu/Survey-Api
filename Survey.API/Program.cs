using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Survey.API.Filters;
using Survey.Application.Mapping;
using Survey.Application.Repository;
using Survey.Application.Services.Implemantations;
using Survey.Application.Services.Interfaces;
using Survey.Domain.Entities;
using Survey.Infrastructure.Persistence;
using Survey.Infrastructure.Persistence.Repository;


var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Controllers + Filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ModelValidationFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
});

// Generic Repository kaydý (BU ÇOK ÖNEMLÝ)
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

// Servisler
builder.Services.AddScoped<ISurveyReaderService, SurveyReaderService>();
builder.Services.AddScoped<ISurveyWriterService, SurveyWriterService>();
builder.Services.AddScoped<ISurveyPaginationService, SurveyPaginationService>();
builder.Services.AddScoped<IRepository<Option>, GenericRepository<Option>>();



// AutoMapper
builder.Services.AddAutoMapper(typeof(SurveyProfile).Assembly);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

