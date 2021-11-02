using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.DataAccess.Utilities
{
    public static class DatabaseInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>(Role.User.ToString()) { Id = 1, NormalizedName = Role.User.ToString().ToUpper() },
                new IdentityRole<int>(Role.Admin.ToString()) { Id = 2, NormalizedName = Role.Admin.ToString().ToUpper() },
                new IdentityRole<int>(Role.Pupil.ToString()) { Id = 3, NormalizedName = Role.Pupil.ToString().ToUpper() },
                new IdentityRole<int>(Role.Teacher.ToString()) { Id = 4, NormalizedName = Role.Teacher.ToString().ToUpper() }
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 1,
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "dmytro.melnyk.v@gmail.com",
                    NormalizedEmail = "DMYTRO.MELNYK.V@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "adm1n_Pass"),
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                }    
            );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 2,
                    UserId = 1
                }    
            );
        }
    }
}
