using Microsoft.EntityFrameworkCore;
using ToDoApp.Common.Exceptions;
using ToDoApp.Common.Models;
using ToDoApp.Data.Data.Abstract;

namespace ToDoApp.Data.Data
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
                await db.Employees.AddAsync((DbEmployee)employee);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            using (ApplicationContext db = Db)
            {
                DbEmployee? employeeToRemove = await db.Employees.FirstOrDefaultAsync(e => e.Id == id);

                if (employeeToRemove != null)
                {
                    db.Entry(employeeToRemove).State = EntityState.Detached;
                    db.Employees.Remove(employeeToRemove);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using (ApplicationContext db = Db)
            {
                return await db.Employees.ToListAsync();
            }
        }

        public async Task<Employee> GetByFullnameAsync(string fullname)
        {
            using (ApplicationContext db = Db)
            {
                DbEmployee? dbEmployee = await db.Employees.FirstOrDefaultAsync(e => e.Fullname == fullname);

                if (dbEmployee == null)
                {
                    throw new NotFoundException(EmployeeNotFoundMessage);
                }

                return dbEmployee;
            }
        }

        public async Task UpdateByIdAsync(Employee employee)
        {
            using (ApplicationContext db = Db)
            {
                DbEmployee? employeeFromDb = await db.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);

                if (employeeFromDb == null)
                {
                    throw new NotFoundException(EmployeeNotFoundMessage);
                }

                employeeFromDb.Fullname = employee.Fullname;
                employeeFromDb.EmploymentDate = employee.EmploymentDate;
                employeeFromDb.Age = employee.Age;
                employeeFromDb.RoleId = employee.RoleId;
                employeeFromDb.SpecialityId = employee.SpecialityId;

                await db.SaveChangesAsync();
            }
        }
    }
}
