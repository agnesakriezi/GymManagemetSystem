using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly DataContext _context;

        public EquipmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipment.ToListAsync();
        }

        public async Task<Equipment> GetByIdAsync(int id)
        {
            return await _context.Equipment.FindAsync(id);
        }

        public async Task AddAsync(Equipment equipment)
        {
            await _context.Equipment.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            _context.Equipment.Update(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
