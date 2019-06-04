using System.Collections.Generic;
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
        public async Task<AppUser> FindAsync(string id)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetProductByUser(string userId)
        {
            var user = await _appDbContext.Users.Include(x => x.AppUserProduct).SingleOrDefaultAsync(x => x.Id == userId);
            var product = new List<Product>();

            foreach(var i in user.AppUserProduct)
            {
                var p = await _appDbContext.Products.Where(x => x.Id == i.ProductId).SingleOrDefaultAsync();
                product.Add(p);
            }

            return product;
        }

        public async Task LevelUpAsync(AppUser user)
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