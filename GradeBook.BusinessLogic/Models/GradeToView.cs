﻿namespace GradeBook.BusinessLogic.Models
{
    public class GradeToView
    {
        public string PupilName { get; set; }
        public int Mark { get; set; }
        public bool IsAbsent { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public string SubjectName { get; set; }
    }
}
