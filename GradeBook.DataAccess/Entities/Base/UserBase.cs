using Microsoft.AspNetCore.Identity;
using System;

namespace GradeBook.DataAccess.Entities.Base
{
    public class UserBase : EntityBase
    {
        public int UserId { get; set; }
        public virtual IdentityUser<int> User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
