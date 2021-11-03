using System.Collections.Generic;

namespace GradeBook.Models.Read
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
