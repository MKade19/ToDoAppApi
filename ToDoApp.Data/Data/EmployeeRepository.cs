using Microsoft.EntityFrameworkCore;
using ToDoApp.Common.Exceptions;
using ToDoApp.Common.Models;
using ToDoApp.Data.Data.Abstract;

namespace ToDoApp.Data.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private const string EmployeeNotFoundMessage = "There is no such an employee!";
        private const string EmployeeAlreadyExistsMessage = "There is an employee with this title!";

        private readonly ApplicationContext Db;

        public EmployeeRepository(ApplicationContext db)
        {
            Db = db;
        }

        public async Task CreateOneAsync(Employee employee)
        {
            using (ApplicationContext db = Db)
            {
                Employee? dbEmployee = await db.Employees.FirstOrDefaultAsync(e => e.Fullname == employee.Fullname);

                if (dbEmployee != null)
                {
                    throw new BadRequestException(EmployeeAlreadyExistsMessage);
                }

                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            using (ApplicationContext db = Db)
            {
                Employee? employeeToRemove = await db.Employees.FirstOrDefaultAsync(e => e.Id == id);

                if (employeeToRemove != null)
                {
                    db.Entry(employeeToRemove).State = EntityState.Detached;
                    db.Employees.Remove(employeeToRemove);
                    await db.SaveChangesAsync();
                }
            }
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PublicEmployee>> GetAllPublicAsync()
        {
            using (ApplicationContext db = Db)
            {
                List<PublicEmployee> employees = await db.Employees
                    .Include(e => e.Role)
                    .Include(e => e.Speciality)
                    .Select(e => new PublicEmployee()
                    {
                        Id = e.Id,
                        Username = e.Username,
                        Fullname = e.Fullname,
                        EmploymentDate = e.EmploymentDate,
                        Age = e.Age,
                        Role = e.Role,
                        Speciality = e.Speciality
                    })
                    .ToListAsync();

                return employees;
            }
        }

        public async Task<PublicEmployee> GetByFullnameAsync(string fullname)
        {
            using (ApplicationContext db = Db)
            {
                PublicEmployee? employee = await db.Employees
                    .Where(e => e.Fullname == fullname)
                    .Include(e => e.Role)
                    .Include(e => e.Speciality)
                    .Select(e => new PublicEmployee()
                    {
                        Id = e.Id,
                        Username = e.Username,
                        Fullname = e.Fullname,
                        EmploymentDate = e.EmploymentDate,
                        Age = e.Age,
                        Role = e.Role,
                        Speciality = e.Speciality
                    })
                    .FirstOrDefaultAsync();

                if (employee == null)
                {
                    throw new NotFoundException(EmployeeNotFoundMessage);
                }

                return employee;
            }
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PublicEmployee> GetByIdPublicAsync(int id)
        {
            using (ApplicationContext db = Db)
            {
                PublicEmployee? employee = await db.Employees
                    .Where(e => e.Id == id)
                    .Include(e => e.Role)
                    .Include(e => e.Speciality)
                    .Select(e => new PublicEmployee()
                    {
                        Id = e.Id,
                        Username = e.Username,
                        Fullname = e.Fullname,
                        EmploymentDate = e.EmploymentDate,
                        Age = e.Age,
                        Role = e.Role,
                        Speciality = e.Speciality,
                    })
                    .FirstOrDefaultAsync();

                if (employee == null)
                {
                    throw new NotFoundException(EmployeeNotFoundMessage);
                }

                return employee;
            }
        }

        public async Task UpdateByIdAsync(Employee employee)
        {
            using (ApplicationContext db = Db)
            {
                Employee? employeeFromDb = await db.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);

                if (employeeFromDb == null)
                {
                    throw new NotFoundException(EmployeeNotFoundMessage);
                }

                employeeFromDb.Username = employee.Username;
                employeeFromDb.Fullname = employee.Fullname;
                employeeFromDb.EmploymentDate = employee.EmploymentDate;
                employeeFromDb.Age = employee.Age;
                employeeFromDb.RoleId = employee.RoleId;
                employeeFromDb.SpecialityId = employee.SpecialityId;

                if (!string.IsNullOrEmpty(employee.Password))
                {
                    employeeFromDb.Password = employee.Password;
                    employeeFromDb.Salt = employee.Salt;
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
