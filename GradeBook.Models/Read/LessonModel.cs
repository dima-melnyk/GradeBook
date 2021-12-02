namespace GradeBook.Models.Read
{
    public class LessonModel
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public string Date { get; set; }
#nullable enable
        public string? Theme { get; set; }
    }
}
