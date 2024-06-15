using GymManagementSystem.Models;
using GymManagemetSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<bool> UserExistsAsync(string username);
    }
}
