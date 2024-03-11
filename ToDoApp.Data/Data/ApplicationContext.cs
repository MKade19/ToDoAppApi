using Microsoft.EntityFrameworkCore;
using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<PublicEmployee> Employees { get; set; } = null!;
    }
}
