using System;
using System.Collections.Generic;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class Pupil : UserBase
    {
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public List<Grade> Grades { get; set; } 
    }
}
