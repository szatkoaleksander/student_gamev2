using System.Threading.Tasks;
using student_game.backend.Models;

namespace student_game.backend.Services
{
    public interface IAccountService
    {
        Task<string> Login(string email, string password);
        Task Register(string username, string email, string password); 
    }
}