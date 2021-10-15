using System;

namespace GradeBook.API.Models
{
    public class CreatePupil
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int ClassId { get; set; }
    }
}
