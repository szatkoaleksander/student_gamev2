using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace student_game.backend.Security
{
    public interface IJwtToken
    {
        Task<string> GenerateJwtToken(string email, IdentityUser user);
    }
}