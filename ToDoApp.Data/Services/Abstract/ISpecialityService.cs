using ToDoApp.Common.Models;

namespace ToDoApp.Data.Services.Abstract
{
    public interface ISpecialityService : IDataService<Speciality>
    {
        Task<Speciality> GetByTitleAsync(string title);
    }
}
