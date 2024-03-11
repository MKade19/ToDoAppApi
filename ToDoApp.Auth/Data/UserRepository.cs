using Microsoft.EntityFrameworkCore;
using ToDoApp.Auth.Data.Abstract;
using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext Db;

        public UserRepository(ApplicationContext db)
        {
            Db = db;
        }

        public async Task CreateOneAsync(Employee user)
        {
            using (ApplicationContext db = Db)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Employee?> GetByUsername(string username)
        {
            using (ApplicationContext db = Db)
            {
                return await Db.Users.Include(nameof(Employee.Role)).FirstOrDefaultAsync(u => u.Username == username);
            }
        }
    }
}
