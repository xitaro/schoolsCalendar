using Microsoft.EntityFrameworkCore;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar1.Data
{
    public class SchoolsCalendarContext : DbContext
    {
        public SchoolsCalendarContext(DbContextOptions<SchoolsCalendarContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

    }
}
