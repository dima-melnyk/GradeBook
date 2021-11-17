using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.DataAccess.Entities
{
    public class UserClass : EntityBase
    {
        public virtual ApplicationUser User { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
