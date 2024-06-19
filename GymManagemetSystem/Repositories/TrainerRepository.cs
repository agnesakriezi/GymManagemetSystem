using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DataContext _context;

        public TrainerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            return await _context.Trainers.ToListAsync();
        }

        public async Task<Trainer> GetByIdAsync(int id)
        {
            return await _context.Trainers.FindAsync(id);
        }

        public async Task AddAsync(Trainer trainer)
        {
            await _context.Trainers.AddAsync(trainer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trainer trainer)
        {
            _context.Trainers.Update(trainer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer != null)
            {
                _context.Trainers.Remove(trainer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
