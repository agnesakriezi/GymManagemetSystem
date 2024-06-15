namespace GymManagementSystem.DTOs
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
