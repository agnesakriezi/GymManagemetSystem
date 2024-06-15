namespace GymManagementSystem.DTOs
{
    public class UserLoginResponseDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
