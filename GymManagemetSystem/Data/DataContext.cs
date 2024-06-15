using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Models;
using GymManagemetSystem.Models;


namespace GymManagementSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
    }
}