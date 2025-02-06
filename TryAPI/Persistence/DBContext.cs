using System;
using Microsoft.EntityFrameworkCore;
using TryAPI.Model;

namespace TryAPI.Persistence;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
}
