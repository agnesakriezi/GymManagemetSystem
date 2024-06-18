using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext _context;

        public ScheduleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Schedule> GetScheduleByIdAsync(int id)
        {
            return await _context.Schedules.FindAsync(id);
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task AddScheduleAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScheduleAsync(Schedule schedule)
        {
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
        }
    }
}
