using GymManagementSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public interface IAttendanceService
    {
        Task<AttendanceDTO> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<AttendanceDTO>> GetAllAttendancesAsync();
        Task<AttendanceDTO> AddAttendanceAsync(AttendanceDTO attendanceDto);
        Task<AttendanceDTO> UpdateAttendanceAsync(int id, AttendanceDTO attendanceDto);
        Task DeleteAttendanceAsync(int id);
    }
}
