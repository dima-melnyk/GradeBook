using System;

namespace GradeBook.BusinessLogic.Queries
{
    public class GradeQuery
    {
        public int? PupilId { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }
        public DateTime? Date { get; set; }
    }
}
