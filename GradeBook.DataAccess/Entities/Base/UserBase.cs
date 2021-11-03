using GradeBook.DataAccess.Entities.Base.Interface;
using System.ComponentModel.DataAnnotations;

namespace GradeBook.DataAccess.Entities.Base
{
    public class UserBase : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
