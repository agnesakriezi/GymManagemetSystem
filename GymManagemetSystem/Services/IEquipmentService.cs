using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.DTOs;

namespace GymManagementSystem.Services
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentDTO>> GetAllAsync();
        Task<EquipmentDTO> GetByIdAsync(int id);
        Task AddAsync(EquipmentDTO equipment);
        Task UpdateAsync(EquipmentDTO equipment);
        Task DeleteAsync(int id);
    }
}
