using Microsoft.EntityFrameworkCore;
using ToDoApp.Auth.Data.Abstract;
using ToDoApp.Common.Exceptions;
using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private const string EmployeeNotFoundMessage = "There is no such an employee!";

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

        public async Task<Employee?> GetByUsername(string username)
        {
            using (ApplicationContext db = Db)
            {
                Employee? employee = await db.Employees.Include(e => e.Role).FirstOrDefaultAsync(e => e.Username == username);

                return employee;
            }
        }

        public async Task ChangePasswordAsync(ChangePasswordData changePasswordData)
        {
            using (ApplicationContext db = Db)
            {
                Employee? employee = await db.Employees.FirstOrDefaultAsync(e => e.Username == changePasswordData.Username);

                if (employee == null)
                {
                    throw new NotFoundException(EmployeeNotFoundMessage);
                }

                employee.Password = changePasswordData.Password;
                employee.Salt = changePasswordData.Salt;
                await db.SaveChangesAsync();
            }
        }
    }
}
