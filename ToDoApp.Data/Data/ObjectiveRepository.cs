using Microsoft.EntityFrameworkCore;
using ToDoApp.Common.Exceptions;
using ToDoApp.Common.Models;
using ToDoApp.Data.Data.Abstract;

namespace ToDoApp.Data.Data
{
    public class ObjectiveRepository : IObjectiveRepository
    {
        private const string ObjectiveNotFoundMessage = "There is no such an objective!";
        private const string ObjectiveAlredyExistsMessage = "There is an objective with this title!";

        private readonly ApplicationContext Db;

        public ObjectiveRepository(ApplicationContext db)
        {
            Db = db;
        }

        public async Task CreateOneAsync(Objective objective)
        {
            using (ApplicationContext db = Db)
            {
                Objective? dbObjective = await db.Objectives.FirstOrDefaultAsync(o => o.Title == objective.Title);

                if (dbObjective != null)
                {
                    throw new BadRequestException(ObjectiveAlredyExistsMessage);
                }

                DateTime currentDate = DateTime.Now;
                objective.CreatedDate = currentDate;
                objective.UpdatedDate = currentDate;
                objective.IsCompleted = false;

                await db.Objectives.AddAsync(objective);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            using (ApplicationContext db = Db)
            {
                Objective? objectiveToRemove = await db.Objectives.FirstOrDefaultAsync(o => o.Id == id);

                if (objectiveToRemove != null)
                {
                    db.Entry(objectiveToRemove).State = EntityState.Detached;
                    db.Objectives.Remove(objectiveToRemove);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Objective>> GetAllAsync()
        {
            using (ApplicationContext db = Db)
            {
                return await db.Objectives.ToListAsync();
            }
        }

        public async Task<Objective> GetByTitleAsync(string title)
        {
            using (ApplicationContext db = Db)
            {
                Objective? dbObjective = await db.Objectives.FirstOrDefaultAsync(o => o.Title == title);

                if (dbObjective == null)
                {
                    throw new NotFoundException(ObjectiveNotFoundMessage);
                }

                return dbObjective;
            }
        }

        public async Task<Objective> GetByIdAsync(int id)
        {
            using (ApplicationContext db = Db)
            {
                Objective? dbObjective = await db.Objectives.FirstOrDefaultAsync(o => o.Id == id);

                if (dbObjective == null)
                {
                    throw new NotFoundException(ObjectiveNotFoundMessage);
                }

                return dbObjective;
            }
        }
        
        public async Task<IEnumerable<Objective>> GetByEmployeeIdAsync(int employeeId)
        {
            using (ApplicationContext db = Db)
            {
                return await db.Objectives.Where(o => o.EmployeeId == employeeId).ToListAsync();
            }
        }

        public async Task UpdateByIdAsync(Objective objective)
        {
            using (ApplicationContext db = Db)
            {
                Objective? objectiveFromDb = await db.Objectives.FirstOrDefaultAsync(o => o.Id == objective.Id);

                if (objectiveFromDb == null)
                {
                    throw new NotFoundException(ObjectiveNotFoundMessage);
                }

                objectiveFromDb.Title = objective.Title;
                objectiveFromDb.Desciption = objective.Desciption;
                objectiveFromDb.IsCompleted = objective.IsCompleted;
                objectiveFromDb.UpdatedDate = DateTime.Now;

                await db.SaveChangesAsync();
            }
        }
    }
}
