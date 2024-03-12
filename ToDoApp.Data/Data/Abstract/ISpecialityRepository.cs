using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data.Abstract
{
    public interface ISpecialityRepository : IRepository<Speciality>
    {
        Task<Speciality> GetByTitleAsync(string title);
    }
}
