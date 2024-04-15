using Microsoft.EntityFrameworkCore;
using ToDoApp.Common.Exceptions;
using ToDoApp.Common.Models;
using ToDoApp.Data.Data.Abstract;

namespace ToDoApp.Data.Data
{
    public class RoleRepository : IRoleRepository
    {
        private const string RoleNotFoundMessage = "There is no such an role!";

        private readonly ApplicationContext Db;

        public RoleRepository(ApplicationContext db)
        {
            Db = db;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            using (ApplicationContext db = Db)
            {
                return await db.Roles.ToListAsync();
            }
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            using (ApplicationContext db = Db)
            {
                Role? role = await db.Roles.FirstOrDefaultAsync();

                if (role == null)
                {
                    throw new NotFoundException(RoleNotFoundMessage);
                }

                return role;
            }
        }
    }
}
