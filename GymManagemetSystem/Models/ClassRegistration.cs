namespace GymManagementSystem.Models
{
    public class ClassRegistration
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Member Member { get; set; }
        public Schedule Schedule { get; set; }
    }
}
