using GymManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Repositories
{
    public interface IMembershipRepository
    {
        Task<Membership> GetMembershipByIdAsync(int id);
        Task<IEnumerable<Membership>> GetAllMembershipsAsync();
        Task AddMembershipAsync(Membership membership);
        Task UpdateMembershipAsync(Membership membership);
        Task DeleteMembershipAsync(Membership membership);
    }
}
