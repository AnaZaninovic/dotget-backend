using DotGetBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotGetBackend.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    
    public DbSet<InstructionsDate> InstructionsDates { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
}

