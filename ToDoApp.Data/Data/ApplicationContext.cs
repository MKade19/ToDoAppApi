using Microsoft.EntityFrameworkCore;
using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(u => u.Username)
                .IsUnique();
            
            modelBuilder.Entity<Speciality>()
                .HasIndex(u => u.Title)
                .IsUnique();

            modelBuilder.Entity<Objective>()
                .HasIndex(u => u.Title)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(u => u.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Speciality> Specialities { get; set; } = null!;
        public DbSet<Objective> Objectives { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
    }
}
