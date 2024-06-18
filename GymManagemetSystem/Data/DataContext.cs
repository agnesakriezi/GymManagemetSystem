using GymManagementSystem.Models;
using GymManagemetSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Billing> Billings { get; set; } 
        public DbSet<Schedule> Schedules { get; set; } 
    }
}
