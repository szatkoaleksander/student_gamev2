using System.Threading.Tasks;
using student_game.backend.Models;
using student_game.backend.ViewModels;

namespace student_game.backend.Services
{
    public interface IAccountService
    {
        Task<JwtViewModel> Login(string email, string password);
        Task Register(string username, string email, string password); 
    }
}