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
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendancesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (attendance == null)
                return NotFound();

            return Ok(attendance);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendance(AttendanceDTO attendanceDto)
        {
            var attendance = await _attendanceService.AddAttendanceAsync(attendanceDto);
            if (attendance == null)
                return BadRequest(new { message = "Invalid membership ID." });

            return CreatedAtAction(nameof(GetAttendanceById), new { id = attendance.Id }, attendance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, AttendanceDTO attendanceDto)
        {
            var attendance = await _attendanceService.UpdateAttendanceAsync(id, attendanceDto);
            if (attendance == null)
                return NotFound();

            return Ok(new { message = "Attendance updated successfully", attendance });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            await _attendanceService.DeleteAttendanceAsync(id);
            return Ok(new { message = "Attendance deleted successfully" });
        }
    }
}
