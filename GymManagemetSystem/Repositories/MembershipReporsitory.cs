using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly DataContext _context;

        public MembershipRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Membership> GetMembershipByIdAsync(int id)
        {
            return await _context.Memberships.FindAsync(id);
        }

        public async Task<IEnumerable<Membership>> GetAllMembershipsAsync()
        {
            return await _context.Memberships.ToListAsync();
        }

        public async Task AddMembershipAsync(Membership membership)
        {
            await _context.Memberships.AddAsync(membership);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMembershipAsync(Membership membership)
        {
            // Attach the membership to the context and mark it as modified
            _context.Attach(membership);
            _context.Entry(membership).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMembershipAsync(Membership membership)
        {
            _context.Memberships.Remove(membership);
            await _context.SaveChangesAsync();
        }
    }
}
