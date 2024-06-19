using System.Text.Json.Serialization;

namespace GymManagementSystem.DTOs
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
        public DateTime HireDate { get; set; }
        [JsonIgnore]
        public ICollection<ScheduleDTO>? Schedules { get; set; }
    }
}
