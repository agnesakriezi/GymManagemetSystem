using GymManagementSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public interface IMembershipService
    {
        Task<MembershipDTO> GetMembershipByIdAsync(int id);
        Task<IEnumerable<MembershipDTO>> GetAllMembershipsAsync();
        Task<MembershipDTO> AddMembershipAsync(MembershipDTO membershipDto);
        Task<MembershipDTO> UpdateMembershipAsync(int id, MembershipDTO membershipDto);
        Task DeleteMembershipAsync(int id);
    }
}
