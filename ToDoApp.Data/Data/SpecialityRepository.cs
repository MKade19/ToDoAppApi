using Microsoft.EntityFrameworkCore;
using ToDoApp.Common.Exceptions;
using ToDoApp.Common.Models;
using ToDoApp.Data.Data.Abstract;

namespace ToDoApp.Data.Data
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private const string SpecialityNotFoundMessage = "There is no such a speciality!";
        private const string SpecialityAlreadyExistsMessage = "There is a speciality with this title!";

        private readonly ApplicationContext Db;

        public SpecialityRepository(ApplicationContext db)
        {
            Db = db;
        }

        public async Task CreateOneAsync(Speciality speciality)
        {
            using (ApplicationContext db = Db)
            {
                Speciality? specialityFromDb = await db.Specialities.FirstOrDefaultAsync(s => s.Title == speciality.Title);

                if (specialityFromDb != null)
                {
                    throw new BadRequestException(SpecialityAlreadyExistsMessage);
                }

                await db.Specialities.AddAsync(speciality);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            using (ApplicationContext db = Db)
            {
                Speciality? specialityToRemove = await db.Specialities.FirstOrDefaultAsync(e => e.Id == id);

                if (specialityToRemove != null)
                {
                    db.Entry(specialityToRemove).State = EntityState.Detached;
                    db.Specialities.Remove(specialityToRemove);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Speciality>> GetAllAsync()
        {
            using (ApplicationContext db = Db)
            {
                return await db.Specialities.ToListAsync();
            }
        }

        public async Task<Speciality> GetByIdAsync(int id)
        {
            using (ApplicationContext db = Db)
            {
                Speciality? speciality = await db.Specialities.FirstOrDefaultAsync(s => s.Id == id);

                if (speciality == null)
                {
                    throw new NotFoundException(SpecialityNotFoundMessage);
                }

                return speciality;
            }
        }

        public async Task<Speciality> GetByTitleAsync(string title)
        {
            using (ApplicationContext db = Db)
            {
                Speciality? speciality = await db.Specialities.FirstOrDefaultAsync(s => s.Title == title);

                if (speciality == null)
                {
                    throw new NotFoundException(SpecialityNotFoundMessage);
                }

                return speciality;
            }
        }

        public async Task UpdateByIdAsync(Speciality speciality)
        {
            using (ApplicationContext db = Db)
            {
                Speciality? specialityFromDb = await db.Specialities.FirstOrDefaultAsync(s => s.Id == speciality.Id);

                if (specialityFromDb == null)
                {
                    throw new NotFoundException(SpecialityNotFoundMessage);
                }

                specialityFromDb.Title = speciality.Title;

                await db.SaveChangesAsync();
            }
        }
    }
}
