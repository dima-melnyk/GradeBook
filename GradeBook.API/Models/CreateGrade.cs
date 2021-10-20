using System.ComponentModel.DataAnnotations;

namespace GradeBook.API.Models
{
    public class CreateGrade
    {
        public int LessonId { get; set; }
        public int PupilId { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Grade outside the range of evaluation ")]
        public int Mark { get; set; }
        public bool IsAbsent { get; set; } = false;
#nullable enable
        public string? Comment { get; set; }

    }
}
