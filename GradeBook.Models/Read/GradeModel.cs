namespace GradeBook.Models.Read
{
    public class GradeModel
    {
        public string PupilName { get; set; }
        public int Mark { get; set; }
        public bool IsAbsent { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
    }
}
