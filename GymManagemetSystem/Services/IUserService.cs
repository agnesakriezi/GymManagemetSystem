using GymManagementSystem.DTOs;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUser(UserDTO userDto);
        Task<UserLoginResponseDTO> Login(LoginDTO loginDto);
    }
}
