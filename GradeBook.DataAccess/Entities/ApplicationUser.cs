using GradeBook.DataAccess.Entities.Base.Interface;
using Microsoft.AspNetCore.Identity;
using System;

namespace GradeBook.DataAccess.Entities
{
    public enum Role
    {
        User,
        Admin,
        Pupil,
        Teacher
    }

    public class ApplicationUser : IdentityUser<int>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
