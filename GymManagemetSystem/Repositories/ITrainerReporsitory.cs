using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.Models;

namespace GymManagementSystem.Repositories
{
    public interface ITrainerRepository
    {
        Task<IEnumerable<Trainer>> GetAllAsync();
        Task<Trainer> GetByIdAsync(int id);
        Task AddAsync(Trainer trainer);
        Task UpdateAsync(Trainer trainer);
        Task DeleteAsync(int id);
    }
}
