using GradeBook.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.DataAccess
{
    public class GBContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public GBContext(DbContextOptions<GBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Grade>()
                .Property(g => g.IsAbsent)
                .HasDefaultValue(false);
            builder.Entity<Lesson>()
                .Property(l => l.Date)
                .HasDefaultValueSql("getdate()");
        }
    }
}
