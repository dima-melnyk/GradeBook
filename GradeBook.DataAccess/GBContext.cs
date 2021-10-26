using GradeBook.DataAccess.Entities;
using GradeBook.DataAccess.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.DataAccess
{
    public class GBContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
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
            base.OnModelCreating(builder);
            builder.Entity<Grade>()
                .Property(g => g.IsAbsent)
                .HasDefaultValue(false);
            builder.Entity<Lesson>()
                .Property(l => l.Date)
                .HasDefaultValueSql("getdate()");
            builder.Entity<Grade>()
                .HasOne(g => g.Lesson)
                .WithMany(l => l.Grades)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Seed();
        }
    }
}
