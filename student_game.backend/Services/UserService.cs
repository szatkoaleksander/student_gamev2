using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student_game.backend.Database;
using student_game.backend.Models;

namespace student_game.backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<AppUser> FindAsync(string id)
        {
            return _appDbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task LevelUpAsync(AppUser user, int val)
        {
            var exp = user.Exp;

            if(user.Exp == 100)
            {
                user.Lvl = 2;
                user.Attack += 10;
                user.Defense += 5;
            }
            else if(user.Exp == 200)
            {
                user.Lvl = 3;
                user.Attack += 10;
                user.Defense += 5;
            }
            else if(user.Exp == 400)
            {
                user.Lvl = 4;
                user.Attack += 10;
                user.Defense += 5;
            }
            else if(user.Exp == 500)
            {
                user.Lvl = 5;
                user.Attack += 10;
                user.Defense += 5;
            }
            else if(user.Exp == 600)
            {
                user.Lvl = 6;
                user.Attack += 10;
                user.Defense += 5;
            }

            await UpdateAsync(user);
        }

        public async Task UpdateAsync(AppUser appUser)
        {
            _appDbContext.Users.Update(appUser);
            await _appDbContext.SaveChangesAsync();
        }
    }
}