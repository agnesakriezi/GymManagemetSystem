using GymManagementSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public interface IScheduleService
    {
        Task<ScheduleDTO> GetScheduleByIdAsync(int id);
        Task<IEnumerable<ScheduleDTO>> GetAllSchedulesAsync();
        Task<ScheduleDTO> AddScheduleAsync(ScheduleDTO scheduleDto);
        Task<ScheduleDTO> UpdateScheduleAsync(int id, ScheduleDTO scheduleDto);
        Task DeleteScheduleAsync(int id);
    }
}
