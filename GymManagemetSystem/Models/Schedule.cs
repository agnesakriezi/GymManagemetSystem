using System;

namespace GymManagementSystem.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string TrainerName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxParticipants { get; set; }
    }
}
