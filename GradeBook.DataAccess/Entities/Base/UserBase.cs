namespace GradeBook.DataAccess.Entities.Base
{
    public class UserBase : EntityBase
    {
        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
