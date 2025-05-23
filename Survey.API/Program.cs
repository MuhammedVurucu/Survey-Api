using Microsoft.EntityFrameworkCore;
using Survey.Application.Mapping;
using Survey.Application.Repository;
using Survey.Application.Services.Implemantations;
using Survey.Application.Services.Interfaces;
using Survey.Infrastructure.Persistence;
using Survey.Infrastructure.Persistence.Repository;


var builder = WebApplication.CreateBuilder(args);

// PostgreSQL connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// PostgreSQL i�in DbContext'i ekle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Controller'lar� ekle (API controller'lar�n� kullanmak i�in zorunlu)
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);



// Swagger servisini ekle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger middleware'ini aktif et
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware ve routing ayarlar�
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
