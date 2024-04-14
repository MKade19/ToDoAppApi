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

        public async Task CreateOneAsync(Employee employee)
        {
            using (ApplicationContext db = Db)
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Employee?> GetByUsername(string fullname)
        {
            using (ApplicationContext db = Db)
            {
                return await Db.Employees.Include(nameof(Employee.Role)).FirstOrDefaultAsync(u => u.Fullname == fullname);
            }
        }
    }
}
