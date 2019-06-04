using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using student_game.backend.ViewModels;

namespace student_game.backend.Security
{
    public interface IJwtToken
    {
        Task<JwtViewModel> GenerateJwtToken(string email, IdentityUser user);
    }
}