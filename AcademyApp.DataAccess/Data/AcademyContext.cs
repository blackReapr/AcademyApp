using AcademyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AcademyApp.DataAccess.Data;

public class AcademyContext : DbContext
{
    public AcademyContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
