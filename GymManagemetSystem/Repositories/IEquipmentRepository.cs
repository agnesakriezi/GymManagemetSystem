using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.Models;

namespace GymManagementSystem.Repositories
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment> GetByIdAsync(int id);
        Task AddAsync(Equipment equipment);
        Task UpdateAsync(Equipment equipment);
        Task DeleteAsync(int id);
    }
}
