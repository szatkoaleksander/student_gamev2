using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_game.backend.Services;
using student_game.backend.ViewModels;

namespace student_game.backend.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize]
        [Route("[action]")]
        public async Task<IActionResult> Me()
        {
            return Ok(LoggedInUser);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            var token = await _accountService.Login(loginViewModel.Email, loginViewModel.Password);

            return Json(token);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel registerViewModel)
        {
            await _accountService.Register(registerViewModel.Username, registerViewModel.Email, registerViewModel.Password);

            return Created($"users/{registerViewModel.Username}", new object());
        }  
    }
}