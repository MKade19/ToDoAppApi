using Microsoft.EntityFrameworkCore;
using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
    }
}
