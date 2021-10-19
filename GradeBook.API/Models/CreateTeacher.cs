using System;

namespace GradeBook.API.Models
{
    public class CreateTeacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
