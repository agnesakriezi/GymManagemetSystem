using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDTO>>> GetAll()
        {
            var equipment = await _equipmentService.GetAllAsync();
            return Ok(equipment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDTO>> GetById(int id)
        {
            var equipment = await _equipmentService.GetByIdAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] EquipmentDTO equipmentDTO)
        {
            await _equipmentService.AddAsync(equipmentDTO);
            return CreatedAtAction(nameof(GetById), new { id = equipmentDTO.Id }, equipmentDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EquipmentDTO equipmentDTO)
        {
            if (id != equipmentDTO.Id)
            {
                return BadRequest();
            }

            await _equipmentService.UpdateAsync(equipmentDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _equipmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
