using GymManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Repositories
{
    public interface IScheduleRepository
    {
        Task<Schedule> GetScheduleByIdAsync(int id);
        Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
        Task AddScheduleAsync(Schedule schedule);
        Task UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(Schedule schedule);
    }
}
