using System;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class Lesson : EntityBase
    {
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public DateTime Date { get; set; }
        public string? Theme { get; set; }
    }
}
