namespace GymManagementSystem.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        public Membership Membership { get; set; }
    }
}
