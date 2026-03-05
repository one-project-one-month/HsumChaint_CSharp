using HsumChaint.Application.Mappings;
using HsumChaint.Application.ServiceInterfaces;
using HsumChaint.Application.Services;
using HsumChaint.Infrastructure.Models;
using HsumChaint.Infrastructure.Repositories;
using HsumChaint.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(typeof(DtoToEntityMappingProfile).Assembly);
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
