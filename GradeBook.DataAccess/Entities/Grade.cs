using System;
using System.ComponentModel.DataAnnotations;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class Grade : EntityBase
    {  
        public virtual Lesson Lesson { get; set; }
        public virtual Pupil Pupil { get; set; }

        [Range(1, 12)]
        public int Mark { get; set; }
        public bool IsAbsent { get; set; } = true;
        public string Comment { get; set; }
    }
}
