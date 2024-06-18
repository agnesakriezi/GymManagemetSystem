namespace GymManagementSystem.DTOs
{
    public class BillingDTO
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
