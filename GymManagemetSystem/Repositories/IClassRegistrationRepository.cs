using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.Models;

namespace GymManagementSystem.Repositories
{
    public interface IClassRegistrationRepository
    {
        Task<IEnumerable<ClassRegistration>> GetAllAsync();
        Task<ClassRegistration> GetByIdAsync(int id);
        Task AddAsync(ClassRegistration classRegistration);
        Task UpdateAsync(ClassRegistration classRegistration);
        Task DeleteAsync(int id);
    }
}
