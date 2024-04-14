using Microsoft.AspNetCore.Mvc;
using ToDoApp.Common.Models;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Controllers
{
    [ApiController]
    [Route("api/to-do-app/objectives")]
    public class ObjectiveController : ControllerBase
    {
        private readonly IObjectiveService _objectiveService;

        public ObjectiveController(IObjectiveService objectiveService)
        {
            _objectiveService = objectiveService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IEnumerable<Objective>> GetAllAsync()
        {
            return await _objectiveService.GetAllAsync();
        }

        [HttpGet("{title}")]
        //[Authorize]
        public async Task<Objective> GetByTitleAsync(string title)
        {
            return await _objectiveService.GetByTitleAsync(title);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult> CreateOneAsync([FromBody] Objective objective)
        {
            await _objectiveService.CreateOneAsync(objective);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        //[Authorize]
        public async Task UpdateByIdAsync([FromBody] Objective objective)
        {
            await _objectiveService.UpdateByIdAsync(objective);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task DeleteByIdAsync(int id)
        {
            await _objectiveService.DeleteByIdAsync(id);
        }
    }
}
