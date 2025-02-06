using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using TryAPI.Persistence;
using TryAPI.Profiles;
using TryAPI.Repositoriies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProfessorRepository, ProfessorsRepository>();
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();

builder.Services.AddAutoMapper(typeof(StudentProfiles).Assembly);
builder.Services.AddAutoMapper(typeof(ProfessorProfiles).Assembly);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
