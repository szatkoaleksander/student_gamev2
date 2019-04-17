using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using student_game.backend.Database;
using student_game.backend.Models;
using student_game.backend.Security;

namespace student_game.backend.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IJwtToken _jwtToken;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(AppDbContext appDbContext, IJwtToken jwtToken, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _appDbContext = appDbContext;
            _jwtToken = jwtToken;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Email == email);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, password, isPersistent: false, lockoutOnFailure: false);

            if(!result.Succeeded) 
            {
                throw new Exception("Invalid credentials");
            }

            return await _jwtToken.GenerateJwtToken(email, user);
        }

        public async Task Register(string username, string email, string password) 
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Email == email);

            if(user != null && (user.UserName == username || user.Email == email))
            {
                throw new Exception("Invalid credentials");
            }

            user = new AppUser { UserName = username, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}