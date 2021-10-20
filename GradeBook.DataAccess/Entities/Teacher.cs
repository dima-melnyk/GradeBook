using System.Collections.Generic;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class Teacher : UserBase
    {
        public virtual List<Lesson> Lessons { get; set; }
    }
}
