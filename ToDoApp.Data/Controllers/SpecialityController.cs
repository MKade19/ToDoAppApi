using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Common.Models;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Controllers
{
    [ApiController]
    [Route("api/to-do-app/specialities")]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Speciality>> GetAllAsync()
        {
            return await _specialityService.GetAllAsync();
        }

        [HttpGet("{title}")]
        [Authorize]
        public async Task<Speciality> GetByTitleAsync(string title)
        {
            return await _specialityService.GetByTitleAsync(title);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateOneAsync([FromBody] Speciality speciality)
        {
            await _specialityService.CreateOneAsync(speciality);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Authorize]
        public async Task UpdateByIdAsync([FromBody] Speciality speciality)
        {
            await _specialityService.UpdateByIdAsync(speciality);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task DeleteByIdAsync(int id)
        {
            await _specialityService.DeleteByIdAsync(id);
        }
    }
}
