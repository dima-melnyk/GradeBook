using System;

namespace GradeBook.API.Models
{
    public class CreateLesson
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
#nullable enable
        public string? Theme { get; set; }
    }
}
