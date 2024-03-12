using Microsoft.EntityFrameworkCore;
using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<DbEmployee> Employees { get; set; } = null!;
        public DbSet<Speciality> Specialities { get; set; } = null!;
        public DbSet<Objective> Objectives { get; set; } = null!;
    }
}
