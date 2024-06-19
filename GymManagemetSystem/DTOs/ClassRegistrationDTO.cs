namespace GymManagementSystem.DTOs
{
    public class ClassRegistrationDTO
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
