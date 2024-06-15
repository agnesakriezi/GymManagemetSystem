using GymManagementSystem.DTOs;
using GymManagementSystem.Enums;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using GymManagemetSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<UserDTO> RegisterUser(UserDTO userDto)
        {
            if (await _userRepository.UserExistsAsync(userDto.Username))
            {
                throw new Exception("User already exists");
            }

            var passwordHasher = new PasswordHasher<User>();
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Role = Enum.Parse<Role>(userDto.Role, true)
            };
            user.PasswordHash = passwordHasher.HashPassword(user, userDto.Password);

            await _userRepository.AddUserAsync(user);

            return new UserDTO
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }

        public async Task<UserLoginResponseDTO> Login(LoginDTO loginDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);
            if (user == null)
            {
                return null;
            }

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new UserLoginResponseDTO
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.ToString(),
                Token = tokenString
            };
        }
    }
}
