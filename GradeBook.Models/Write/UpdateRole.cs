using GradeBook.DataAccess.Entities;

namespace GradeBook.Models.Write
{
    public class UpdateRole
    {
        public int Id { get; set; }
        public int? ClassId { get; set; }
        public Role Role { get; set; }
    }
}
