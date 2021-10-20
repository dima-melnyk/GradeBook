namespace GradeBook.BusinessLogic.Models
{
    public class LessonToView
    {
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public string Date { get; set; }
#nullable enable
        public string? Theme { get; set; }
    }
}
