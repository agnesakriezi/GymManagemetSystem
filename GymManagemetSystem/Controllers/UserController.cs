using GymManagementSystem.DTOs;
using GymManagementSystem.Repositories;
using GymManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using GymManagementSystem.Enums;

namespace GymManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Get a user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // Get all users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        // Delete a user by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userRepository.DeleteUserAsync(user);
            return Ok(new { message = "User deleted successfully" });
        }

        // Update a user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO updateUserDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            user.Username = updateUserDto.Username;
            user.Email = updateUserDto.Email;
            user.Role = Enum.Parse<Role>(updateUserDto.Role, true);

            await _userRepository.UpdateUserAsync(user);
            return Ok(new { message = "User updated successfully", user });
        }
    }
}
