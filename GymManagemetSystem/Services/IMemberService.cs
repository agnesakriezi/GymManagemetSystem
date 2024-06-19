using GymManagementSystem.DTOs;

namespace GymManagementSystem.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDTO>> GetAllAsync();
        Task<MemberDTO> GetByIdAsync(int id);
        Task AddAsync(MemberDTO memberDto);
        Task UpdateAsync(MemberDTO memberDto);
        Task DeleteAsync(int id);
    }
}
