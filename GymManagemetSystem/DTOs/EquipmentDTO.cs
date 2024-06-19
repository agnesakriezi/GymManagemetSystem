namespace GymManagementSystem.DTOs
{
    public class EquipmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public bool IsOperational { get; set; }
    }
}
