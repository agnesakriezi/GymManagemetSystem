using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.DTOs;

namespace GymManagementSystem.Services
{
    public interface IClassRegistrationService
    {
        Task<IEnumerable<ClassRegistrationDTO>> GetAllAsync();
        Task<ClassRegistrationDTO> GetByIdAsync(int id);
        Task AddAsync(ClassRegistrationDTO classRegistration);
        Task UpdateAsync(ClassRegistrationDTO classRegistration);
        Task DeleteAsync(int id);
    }
}
