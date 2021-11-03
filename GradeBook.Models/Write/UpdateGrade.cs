using System;
using System.ComponentModel.DataAnnotations;

namespace GradeBook.Models.Write
{
    public class UpdateGrade
    {
        public int LessonId { get; set; }
        public int PupilId { get; set; }
        public int Mark { get; set; }
        public bool IsAbsent { get; set; } = false;
#nullable enable
        public string? Comment { get; set; }
    }
}
