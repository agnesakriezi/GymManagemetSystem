using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ILogger<EquipmentController> _logger;

        public EquipmentController(IEquipmentService equipmentService, ILogger<EquipmentController> logger)
        {
            _equipmentService = equipmentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDTO>>> GetAll()
        {
            _logger.LogInformation("Fetching all equipment");
            try
            {
                var equipment = await _equipmentService.GetAllAsync();
                _logger.LogInformation("Fetched all equipment successfully");
                return Ok(equipment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all equipment");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDTO>> GetById(int id)
        {
            _logger.LogInformation("Fetching equipment with ID {Id}", id);
            try
            {
                var equipment = await _equipmentService.GetByIdAsync(id);
                if (equipment == null)
                {
                    _logger.LogWarning("Equipment with ID {Id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched equipment with ID {Id} successfully", id);
                return Ok(equipment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching equipment with ID {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] EquipmentDTO equipmentDTO)
        {
            _logger.LogInformation("Adding new equipment");
            try
            {
                await _equipmentService.AddAsync(equipmentDTO);
                _logger.LogInformation("Added new equipment with ID {Id} successfully", equipmentDTO.Id);
                return CreatedAtAction(nameof(GetById), new { id = equipmentDTO.Id }, equipmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding new equipment");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EquipmentDTO equipmentDTO)
        {
            if (id != equipmentDTO.Id)
            {
                _logger.LogWarning("Equipment ID mismatch for update: {Id} != {DTOId}", id, equipmentDTO.Id);
                return BadRequest();
            }

            _logger.LogInformation("Updating equipment with ID {Id}", id);
            try
            {
                await _equipmentService.UpdateAsync(equipmentDTO);
                _logger.LogInformation("Updated equipment with ID {Id} successfully", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating equipment with ID {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting equipment with ID {Id}", id);
            try
            {
                await _equipmentService.DeleteAsync(id);
                _logger.LogInformation("Deleted equipment with ID {Id} successfully", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting equipment with ID {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
