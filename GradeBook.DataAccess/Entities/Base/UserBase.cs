using System;

namespace GradeBook.DataAccess.Entities.Base
{
    public class UserBase : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
