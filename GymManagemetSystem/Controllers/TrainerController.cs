using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GymManagementSystem.DTOs;
using GymManagementSystem.Models;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;
        private readonly IMapper _mapper;

        public TrainerController(ITrainerService trainerService, IMapper mapper)
        {
            _trainerService = trainerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainerDTO>>> GetAll()
        {
            var trainers = await _trainerService.GetAllAsync();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerDTO>> GetById(int id)
        {
            var trainer = await _trainerService.GetByIdAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TrainerDTO trainerDTO)
        {
            await _trainerService.AddAsync(trainerDTO);
            return CreatedAtAction(nameof(GetById), new { id = trainerDTO.Id }, trainerDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TrainerDTO trainerDTO)
        {
            if (id != trainerDTO.Id)
            {
                return BadRequest();
            }

            await _trainerService.UpdateAsync(trainerDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _trainerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
