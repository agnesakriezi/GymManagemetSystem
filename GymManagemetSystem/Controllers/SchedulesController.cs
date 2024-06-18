using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var schedule = await _scheduleService.GetScheduleByIdAsync(id);
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedulesAsync();
            return Ok(schedules);
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule(ScheduleDTO scheduleDto)
        {
            var schedule = await _scheduleService.AddScheduleAsync(scheduleDto);
            return CreatedAtAction(nameof(GetScheduleById), new { id = schedule.Id }, schedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, ScheduleDTO scheduleDto)
        {
            var schedule = await _scheduleService.UpdateScheduleAsync(id, scheduleDto);
            if (schedule == null)
                return NotFound();

            return Ok(new { message = "Schedule updated successfully", schedule });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            await _scheduleService.DeleteScheduleAsync(id);
            return Ok(new { message = "Schedule deleted successfully" });
        }
    }
}
