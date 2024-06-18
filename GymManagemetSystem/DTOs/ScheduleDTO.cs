namespace GymManagementSystem.DTOs
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string TrainerName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxParticipants { get; set; }

        // Ensure DateTime values are in UTC
        public DateTime StartTimeUtc => DateTime.SpecifyKind(StartTime, DateTimeKind.Utc);
        public DateTime EndTimeUtc => DateTime.SpecifyKind(EndTime, DateTimeKind.Utc);
    }
}
