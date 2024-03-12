using Microsoft.EntityFrameworkCore;
using ToDoApp.Auth.Data.Abstract;
using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext Db;

        public EmployeeRepository(ApplicationContext db)
        {
            Db = db;
        }

        public async Task CreateOneAsync(DbEmployee employee)
        {
            using (ApplicationContext db = Db)
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
            }
        }

        public async Task<DbEmployee?> GetByUsername(string fullname)
        {
            using (ApplicationContext db = Db)
            {
                return await Db.Employees.Include(nameof(DbEmployee.Role)).FirstOrDefaultAsync(u => u.Fullname == fullname);
            }
        }
    }
}
