using System;

namespace GradeBook.Models.Write
{
    public class UpdatePupil
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int ClassId { get; set; }
    }
}
