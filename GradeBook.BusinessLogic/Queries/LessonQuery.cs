using System;

namespace GradeBook.BusinessLogic.Queries
{
    public class LessonQuery
    {
        public int? TeacherId { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }
        public DateTime? Date { get; set; }
    }
}
