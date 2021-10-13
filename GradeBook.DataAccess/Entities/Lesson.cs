using System;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class Lesson : EntityBase
    {
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public DateTime Date { get; set; }
#nullable enable
        public string? Theme { get; set; }
    }
}
