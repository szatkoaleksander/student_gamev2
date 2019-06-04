using System.Collections.Generic;
using System.Threading.Tasks;
using student_game.backend.Models;

namespace student_game.backend.Services
{
    public interface IUserService
    {
        Task<AppUser> FindAsync(string id);
        Task<List<Product>> GetProductByUser(string userId);
        Task UpdateAsync(AppUser appUser);
        Task LevelUpAsync(AppUser appUser);

    }
}