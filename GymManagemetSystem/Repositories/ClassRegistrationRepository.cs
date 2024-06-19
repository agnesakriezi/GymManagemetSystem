using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories
{
    public class ClassRegistrationRepository : IClassRegistrationRepository
    {
        private readonly DataContext _context;

        public ClassRegistrationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassRegistration>> GetAllAsync()
        {
            return await _context.ClassRegistrations.ToListAsync();
        }

        public async Task<ClassRegistration> GetByIdAsync(int id)
        {
            return await _context.ClassRegistrations.FindAsync(id);
        }

        public async Task AddAsync(ClassRegistration classRegistration)
        {
            await _context.ClassRegistrations.AddAsync(classRegistration);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClassRegistration classRegistration)
        {
            _context.ClassRegistrations.Update(classRegistration);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var classRegistration = await _context.ClassRegistrations.FindAsync(id);
            if (classRegistration != null)
            {
                _context.ClassRegistrations.Remove(classRegistration);
                await _context.SaveChangesAsync();
            }
        }
    }
}
