using GradeBook.Models.Auth;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        Task Register(RegisterUser user);
        Task<string> Login(LoginUser loginUser);
    }
}
