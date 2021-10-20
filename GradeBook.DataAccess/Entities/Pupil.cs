using System;
using System.Collections.Generic;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class Pupil : UserBase
    {
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual List<Grade> Grades { get; set; } 
    }
}
