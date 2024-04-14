using ToDoApp.Common.Models;
using ToDoApp.Data.Data.Abstract;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly ISpecialityRepository _specialityRepository;

        public SpecialityService(ISpecialityRepository specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }

        public async Task CreateOneAsync(Speciality speciality)
        {
            await _specialityRepository.CreateOneAsync(speciality);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _specialityRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Speciality>> GetAllAsync()
        {
            return await _specialityRepository.GetAllAsync();
        }

        public async Task<Speciality> GetByIdAsync(int id)
        {
            return await _specialityRepository.GetByIdAsync(id);
        }

        public async Task<Speciality> GetByTitleAsync(string title)
        {
            return await _specialityRepository.GetByTitleAsync(title);
        }

        public async Task UpdateByIdAsync(Speciality speciality)
        {
            await _specialityRepository.UpdateByIdAsync(speciality);
        }
    }
}
