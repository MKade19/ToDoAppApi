using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Common.Exceptions;
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
        [Authorize]
        public async Task<IEnumerable<Objective>> GetAllAsync()
        {
            return await _objectiveService.GetAllAsync();
        }

        [HttpGet("employee/{employeeId}")]
        [Authorize]
        public async Task<IEnumerable<Objective>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _objectiveService.GetByEmployeeIdAsync(employeeId);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<Objective> GetByIdAsync(int id)
        {
            return await _objectiveService.GetByIdAsync(id);
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IEnumerable<Objective>> GetBySearchDataAsync([FromQuery]ObjectiveSearchData searchData)
        {
            //ObjectiveSearchData searchData = new ObjectiveSearchData()
            //{
            //    Title = title,
            //    Completion = completion,
            //    MinDate = minDate,
            //    MaxDate = maxDate,
            //    EmployeeId = employeeId
            //};

            return await _objectiveService.GetBySearchDataAsync(searchData);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateOneAsync([FromBody] Objective objective)
        {
            await _objectiveService.CreateOneAsync(objective);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Authorize]
        public async Task UpdateByIdAsync([FromBody] Objective objective)
        {
            await _objectiveService.UpdateByIdAsync(objective);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task DeleteByIdAsync(int id)
        {
            await _objectiveService.DeleteByIdAsync(id);
        }
    }
}
