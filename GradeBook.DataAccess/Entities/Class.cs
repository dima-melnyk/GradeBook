using System.Collections.Generic;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class Class : EntityBase
    {
        public string Name { get; set; }
        public List<Pupil> Pupils { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
