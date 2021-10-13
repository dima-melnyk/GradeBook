using System;

namespace GradeBook.BusinessLogic.DTOs
{
    public class CreatePupilDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int ClassId { get; set; }
    }
}
