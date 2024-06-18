using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly DataContext _context;

        public BillingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Billing> GetBillingByIdAsync(int id)
        {
            return await _context.Billings.FindAsync(id);
        }

        public async Task<IEnumerable<Billing>> GetAllBillingsAsync()
        {
            return await _context.Billings.ToListAsync();
        }

        public async Task AddBillingAsync(Billing billing)
        {
            await _context.Billings.AddAsync(billing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBillingAsync(Billing billing)
        {
            _context.Billings.Update(billing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBillingAsync(Billing billing)
        {
            _context.Billings.Remove(billing);
            await _context.SaveChangesAsync();
        }
    }
}
