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
        public DbSet<ClassRegistration> ClassRegistrations { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        // Override SaveChanges to convert DateTime to UTC
        public override int SaveChanges()
        {
            ConvertDateTimesToUtc();
            return base.SaveChanges();
        }

        // Override SaveChangesAsync to convert DateTime to UTC
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ConvertDateTimesToUtc();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ConvertDateTimesToUtc()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entity in entities)
            {
                var properties = entity.Entity.GetType().GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        var dateTime = (DateTime)property.GetValue(entity.Entity);
                        if (dateTime.Kind == DateTimeKind.Unspecified)
                        {
                            property.SetValue(entity.Entity, DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));
                        }
                        else if (dateTime.Kind == DateTimeKind.Local)
                        {
                            property.SetValue(entity.Entity, dateTime.ToUniversalTime());
                        }
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        var dateTime = (DateTime?)property.GetValue(entity.Entity);
                        if (dateTime.HasValue)
                        {
                            if (dateTime.Value.Kind == DateTimeKind.Unspecified)
                            {
                                property.SetValue(entity.Entity, DateTime.SpecifyKind(dateTime.Value, DateTimeKind.Utc));
                            }
                            else if (dateTime.Value.Kind == DateTimeKind.Local)
                            {
                                property.SetValue(entity.Entity, dateTime.Value.ToUniversalTime());
                            }
                        }
                    }
                }
            }
        }
            }
}
