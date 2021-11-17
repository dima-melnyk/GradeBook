using System;
using System.ComponentModel.DataAnnotations;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class Grade : EntityBase
    {  
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public int PupilId { get; set; }
        public virtual ApplicationUser Pupil { get; set; }

        public int Mark { get; set; }
        public bool IsAbsent { get; set; }
        public string Comment { get; set; }
    }
}
