namespace GymManagementSystem.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
    }
}
