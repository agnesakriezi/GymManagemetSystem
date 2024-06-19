using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRegistrationController : ControllerBase
    {
        private readonly IClassRegistrationService _classRegistrationService;

        public ClassRegistrationController(IClassRegistrationService classRegistrationService)
        {
            _classRegistrationService = classRegistrationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassRegistrationDTO>>> GetAll()
        {
            var classRegistrations = await _classRegistrationService.GetAllAsync();
            return Ok(classRegistrations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassRegistrationDTO>> GetById(int id)
        {
            var classRegistration = await _classRegistrationService.GetByIdAsync(id);
            if (classRegistration == null)
            {
                return NotFound();
            }
            return Ok(classRegistration);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ClassRegistrationDTO classRegistrationDTO)
        {
            await _classRegistrationService.AddAsync(classRegistrationDTO);
            return CreatedAtAction(nameof(GetById), new { id = classRegistrationDTO.Id }, classRegistrationDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ClassRegistrationDTO classRegistrationDTO)
        {
            if (id != classRegistrationDTO.Id)
            {
                return BadRequest();
            }

            await _classRegistrationService.UpdateAsync(classRegistrationDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _classRegistrationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
