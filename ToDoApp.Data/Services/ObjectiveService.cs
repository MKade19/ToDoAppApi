using ToDoApp.Common.Models;
using ToDoApp.Data.Data.Abstract;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Services
{
    public class ObjectiveService : IObjectiveService
    {
        private readonly IObjectiveRepository _objectiveRepository;

        public ObjectiveService(IObjectiveRepository objectiveRepository)
        {
            _objectiveRepository = objectiveRepository;
        }

        public async Task CreateOneAsync(Objective objective)
        {
            await _objectiveRepository.CreateOneAsync(objective);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _objectiveRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Objective>> GetAllAsync()
        {
            return await _objectiveRepository.GetAllAsync();
        }

        public Task<Objective> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Objective> GetByTitleAsync(string title)
        {
            return await _objectiveRepository.GetByTitleAsync(title);
        }

        public async Task UpdateByIdAsync(Objective objective)
        {
            await _objectiveRepository.UpdateByIdAsync(objective);
        }
    }
}
