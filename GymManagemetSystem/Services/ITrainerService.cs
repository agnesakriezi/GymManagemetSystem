using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.DTOs;

namespace GymManagementSystem.Services
{
    public interface ITrainerService
    {
        Task<IEnumerable<TrainerDTO>> GetAllAsync();
        Task<TrainerDTO> GetByIdAsync(int id);
        Task AddAsync(TrainerDTO trainer);
        Task UpdateAsync(TrainerDTO trainer);
        Task DeleteAsync(int id);
    }
}
