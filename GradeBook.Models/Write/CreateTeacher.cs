using System;

namespace GradeBook.Models.Write
{
    public class CreateTeacher
    {
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
