using GradeBook.DataAccess.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.DataAccess.Utilities
{
    public static class DatabaseInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>("User") { Id = 1, NormalizedName = "USER" },
                new IdentityRole<int>("Admin") { Id = 2, NormalizedName = "ADMIN" },
                new IdentityRole<int>("Pupil") { Id = 3, NormalizedName = "PUPIL" },
                new IdentityRole<int>("Teacher") { Id = 4, NormalizedName = "TEACHER" });

            var hasher = new PasswordHasher<IdentityUser<int>>();
            builder.Entity<UserBase>().HasData(
                new UserBase
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
