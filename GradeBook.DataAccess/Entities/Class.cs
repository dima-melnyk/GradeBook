using System.Collections.Generic;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class Class : EntityBase
    {
        public string Name { get; set; }
        public virtual List<UserClass> Pupils { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
    }
}
